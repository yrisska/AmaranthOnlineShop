using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Application.Common.Models;
using AmaranthOnlineShop.Domain;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AmaranthOnlineShop.Application.Application.Checkouts.Commands
{
    /*public class MakeOrderCommand : IRequest<string>
    {
        [JsonIgnore]
        public int ShoppingSessionId { get; set; }
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
            var shoppingSession = await _repository.GetById<ShoppingSession>(request.ShoppingSessionId);
            
            var orderDetail = _mapper.Map<OrderDetail>(request);
            orderDetail.Status = OrderStatus.OrderPaymentDue;
            orderDetail.Total = shoppingSession.Total;

            orderDetail.OrderItems = shoppingSession.CartItems.Select(x => new OrderItem
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity,
            }).ToList();

            await _repository.SaveChangesAsync();

            var redirectUrl =  await _paymentProvider.CreateCheckoutSession(orderDetail.Total, orderDetail.Id);
            return redirectUrl;
        }
    }*/
}
