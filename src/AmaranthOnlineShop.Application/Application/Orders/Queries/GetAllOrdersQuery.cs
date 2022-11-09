using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Domain;
using AutoMapper;
using MediatR;

namespace AmaranthOnlineShop.Application.Application.Orders.Queries
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<OrderDetailListDto>>
    {

    }
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderDetailListDto>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<IEnumerable<OrderDetailListDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _repository.GetAllWithInclude<OrderDetail>(x => x.OrderItems);
            var orderDtoList = _mapper.Map<List<OrderDetailListDto>>(orders);
            return orderDtoList;
        }
    }
    public class OrderDetailListDto
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public ICollection<OrderItemListDto> OrderItems { get; set; }
        public OrderStatus Status { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Comments { get; set; }
    }
    public class OrderItemListDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
