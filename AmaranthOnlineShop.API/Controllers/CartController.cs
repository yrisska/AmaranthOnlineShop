using AmaranthOnlineShop.Application.Application.Cart.Commands;
using AmaranthOnlineShop.Application.Application.Cart.Queries;
using AmaranthOnlineShop.Application.Application.Cart.Responses;
using AmaranthOnlineShop.Application.Application.Products.Commands;
using AmaranthOnlineShop.Application.Application.Products.Queries;
using AmaranthOnlineShop.Application.Application.Products.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmaranthOnlineShop.API.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ShoppingSessionDto> GetCart()
        {
            if (!Request.Cookies.TryGetValue("session", out var session))
                throw new Exception("Does not have any items in cart");

            return await _mediator.Send(new GetCartQuery() {SessionId = session});
        }

        [HttpPost]
        public async Task<ShoppingSessionDto> AddToCart(int productId)
        {
            var hasSessionCookie = Request.Cookies.TryGetValue("session", out var session);

            var sessionDto = await _mediator.Send(new AddToCartCommand() { SessionId = session, ProductId = productId});

            if (!hasSessionCookie)
                Response.Cookies.Append("session", sessionDto.sessionId);
            return sessionDto;
        }
    }
}
