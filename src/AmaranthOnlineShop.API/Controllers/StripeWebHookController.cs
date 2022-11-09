using AmaranthOnlineShop.Application.Application.Orders.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stripe;

namespace AmaranthOnlineShop.API.Controllers
{
    [Route("api/webhook")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class StripeWebHookController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public StripeWebHookController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Index()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            var stripeEvent = EventUtility.ConstructEvent(
                json,
                Request.Headers["Stripe-Signature"],
                _configuration["Stripe:EndpointSecret"]
            );
            string stripeJson = stripeEvent.Data.RawObject + string.Empty;
            var childData = PaymentIntent.FromJson(stripeJson);
            var metadata = childData.Metadata;

            if (!metadata.TryGetValue("orderId", out string strOrderId))
            {
                return BadRequest();
            }

            int.TryParse(strOrderId, out var orderId);

            switch (stripeEvent.Type)
            {
                case Events.PaymentIntentSucceeded:
                    await _mediator.Send(new UpdateOrderStatusCommand
                    {
                        OrderId = orderId,
                        Status = Domain.OrderStatus.OrderPaymentSucceeded
                    });
                    break;

                case Events.PaymentIntentCanceled:
                    await _mediator.Send(new UpdateOrderStatusCommand
                    {
                        OrderId = orderId,
                        Status = Domain.OrderStatus.OrderPaymentFailed
                    });
                    break;
            }

            return Ok();
        }
    }
}