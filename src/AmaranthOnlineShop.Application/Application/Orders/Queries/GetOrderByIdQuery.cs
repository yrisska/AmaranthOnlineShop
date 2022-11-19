using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Domain;
using AutoMapper;
using MediatR;

namespace AmaranthOnlineShop.Application.Application.Orders.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderDetailDto>
    {
        public int Id { get; set; }
    }

    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDetailDto>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<OrderDetailDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetByIdWithInclude<OrderDetail>(request.Id, x => x.OrderItems);
            var orderDto = _mapper.Map<OrderDetailDto>(order);
            return orderDto;
        }
    }

    public class OrderDetailDto
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; }
        public OrderStatus Status { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Comments { get; set; }
    }

    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}