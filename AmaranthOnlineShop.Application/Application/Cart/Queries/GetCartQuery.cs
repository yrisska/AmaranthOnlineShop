using AmaranthOnlineShop.Application.Application.Cart.Responses;
using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Domain;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaranthOnlineShop.Application.Application.Cart.Queries
{
    public class GetCartQuery : IRequest<ShoppingSessionDto>
    {
        public string SessionId { get; set; }
    }
    public class GetCartQueryHandler : IRequestHandler<GetCartQuery, ShoppingSessionDto>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetCartQueryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ShoppingSessionDto> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            var session = await _repository.GetByPredicateWithIncludeThenInclude<ShoppingSession, CartItem>(
                (x) => x.SessionId == request.SessionId,
                (y) => y.CartItems,
                (z) => z.Product
            );

            var sessionDto = _mapper.Map<ShoppingSessionDto>(session);

            return sessionDto;
        }
    }
}
