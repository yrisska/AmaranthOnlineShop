using AmaranthOnlineShop.Application.Application.Orders.Commands;
using AmaranthOnlineShop.Application.Application.Orders.Queries;
using AmaranthOnlineShop.Application.Application.Orders.Responses;
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

        [HttpGet]
        public async Task<IEnumerable<OrderDetailDto>> GetAllOrders()
        {
            var orderDetailsDto = await _mediator.Send(new GetAllOrdersQuery());
            return orderDetailsDto;
        }
        [HttpGet("{id}")]
        public async Task<OrderDetailDto> GetOrderByID(int id)
        {
            var orderDetailDto = await _mediator.Send(new GetOrderByIdQuery() {Id = id});
            return orderDetailDto;
        }
    }
}