using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Application.Common.Models;
using AmaranthOnlineShop.Domain;
using AutoMapper;
using MediatR;

namespace AmaranthOnlineShop.Application.Application.Orders.Queries
{
    public class GetOrdersPagedQuery : IRequest<PaginatedResult<OrderDetailPagedDto>>
    {
        public OrdersPagedRequest OrdersPagedRequest { get; set; }
    }

    public class GetOrdersPagedQueryHandler : IRequestHandler<GetOrdersPagedQuery, PaginatedResult<OrderDetailPagedDto>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetOrdersPagedQueryHandler(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PaginatedResult<OrderDetailPagedDto>> Handle(GetOrdersPagedQuery request, CancellationToken cancellationToken)
        {
            var pagedProductsDto = await _repository.GetPagedData<OrderDetail, OrderDetailPagedDto>(request.OrdersPagedRequest);
            return pagedProductsDto;
        }
    }
    public class OrderDetailPagedDto
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public ICollection<OrderItemPagedDto> OrderItems { get; set; }
        public OrderStatus Status { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Comments { get; set; }
    }
    public class OrderItemPagedDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
