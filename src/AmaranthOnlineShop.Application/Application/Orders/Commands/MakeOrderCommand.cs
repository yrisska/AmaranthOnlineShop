using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Application.Common.Models;
using AmaranthOnlineShop.Domain;
using AutoMapper;
using MediatR;

namespace AmaranthOnlineShop.Application.Application.Orders.Commands
{
    public class MakeOrderCommand : IRequest<string>
    {
        public ICollection<CartItem> CartItems { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Comments { get; set; }
    }
    public class MakeOrderCommandHandler : IRequestHandler<MakeOrderCommand, string>
    {
        private readonly IPaymentProvider _paymentProvider;
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public MakeOrderCommandHandler(IPaymentProvider paymentProvider, IRepository repository, IMapper mapper)
        {
            _paymentProvider = paymentProvider;
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<string> Handle(MakeOrderCommand request, CancellationToken cancellationToken)
        {
            var orderDetail = _mapper.Map<OrderDetail>(request);
            orderDetail.Status = OrderStatus.OrderPaymentDue;

            var products = await _repository.GetRangeByIds<Product>(request.CartItems.Select(x => x.ProductId).ToArray());
            var total = products.Aggregate(0m,
                (x, y) => x + decimal.Round(y.Price * request.CartItems.First(z => z.ProductId == y.Id).Quantity, 2));
            orderDetail.Total = total;

            orderDetail.OrderItems = request.CartItems.Select(x => new OrderItem
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity,
            }).ToList();

            _repository.Add(orderDetail);
            await _repository.SaveChangesAsync();

            var redirectUrl = _paymentProvider.CreateCheckoutSession(orderDetail.Total, orderDetail.Id);
            return redirectUrl;
        }
    }
}
