using AmaranthOnlineShop.Application.Application.Orders.Responses;
using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Domain;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
