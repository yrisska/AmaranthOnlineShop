using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Domain;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmaranthOnlineShop.Application.Application.Orders.Responses;

namespace AmaranthOnlineShop.Application.Application.Orders.Queries
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<OrderDetailDto>>
    {

    }
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderDetailDto>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<IEnumerable<OrderDetailDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _repository.GetAllWithInclude<OrderDetail>(x => x.OrderItems);
            var orderDtoList = _mapper.Map<List<OrderDetailDto>>(orders);
            return orderDtoList;
        }
    }
}
