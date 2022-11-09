using AmaranthOnlineShop.Application.Application.Orders.Commands;
using AmaranthOnlineShop.Application.Application.Orders.Queries;
using AmaranthOnlineShop.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public async Task<MakeOrderCommandResponse> MakeOrder(MakeOrderCommand makeOrderCommand)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
            {
                makeOrderCommand.UserId = userId;
            }
            var response = await _mediator.Send(makeOrderCommand);
            return response;
        }

        [HttpGet]
        [Authorize("access:admin-data")]
        public async Task<IEnumerable<OrderDetailListDto>> GetAllOrders()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orderDetailsDto = await _mediator.Send(new GetAllOrdersQuery());
            return orderDetailsDto;
        }
        [HttpGet("{id}")]
        [Authorize("access:admin-data")]
        public async Task<OrderDetailDto> GetOrderByID(int id)
        {
            var orderDetailDto = await _mediator.Send(new GetOrderByIdQuery() {Id = id});
            return orderDetailDto;
        }
        [HttpGet("user-paginated-search")]
        [Authorize]
        public async Task<PaginatedResult<OrderDetailPagedDto>> GetPagedUserOrders([FromQuery] OrdersPagedRequest ordersPagedRequest)
        {
            ordersPagedRequest.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var pagedOrdersDto = await _mediator.Send(new GetOrdersPagedQuery { OrdersPagedRequest = ordersPagedRequest });
            return pagedOrdersDto;
        }
        [HttpGet("paginated-search")]
        [Authorize("access:admin-data")]
        public async Task<PaginatedResult<OrderDetailPagedDto>> GetPagedOrders([FromQuery] OrdersPagedRequest ordersPagedRequest)
        {
            var pagedOrdersDto = await _mediator.Send(new GetOrdersPagedQuery { OrdersPagedRequest = ordersPagedRequest });
            return pagedOrdersDto;
        }
    }
}