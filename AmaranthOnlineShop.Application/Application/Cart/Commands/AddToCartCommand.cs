using AmaranthOnlineShop.Application.Application.Cart.Responses;
using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Domain;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AmaranthOnlineShop.Application.Application.Cart.Commands
{
    public class AddToCartCommand : IRequest<ShoppingSessionDto>
    {
        public string SessionId { get; set; }
        public int ProductId { get; set; }
    }
    public class AddToCartCommandHandler : IRequestHandler<AddToCartCommand, ShoppingSessionDto>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AddToCartCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ShoppingSessionDto> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            ShoppingSession session;
            if (!string.IsNullOrEmpty(request.SessionId))
            {
                session = await _repository.GetByPredicateWithIncludeThenInclude<ShoppingSession, CartItem>(
                    (x) => x.SessionId == request.SessionId,
                    (y) => y.CartItems,
                    (z) => z.Product
                    );

                var cartItem = session.CartItems.FirstOrDefault(x => x.ProductId == request.ProductId);
                if (cartItem != null)
                {
                    cartItem.Quantity++;
                }
                else
                {
                    var product = await _repository.GetById<Product>(request.ProductId);
                    session.CartItems.Add(new CartItem
                    {
                        Product = product,
                        Quantity = 1
                    });
                }
            }
            else
            {
                var product = await _repository.GetById<Product>(request.ProductId);
                session = new ShoppingSession { SessionId = Guid.NewGuid().ToString() };
                session.CartItems.Add(new CartItem
                {
                    Product = product,
                    Quantity = 1
                });
            }

            session.Total = session.CartItems.Aggregate(0m, (total, cartItem) =>
                total + decimal.Round(cartItem.Product.Price * cartItem.Quantity, 2));

            var sessionDto = _mapper.Map<ShoppingSessionDto>(session);
            return sessionDto;
        }
    }
}
