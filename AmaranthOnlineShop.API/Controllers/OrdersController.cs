using AmaranthOnlineShop.Application.Application.Orders.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AmaranthOnlineShop.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task MakeOrder(MakeOrderCommand makeOrderCommand)
        {
            var response = await _mediator.Send(makeOrderCommand);
            Response.Headers.Location = response;
            Response.StatusCode = 303;
        }
    }
}