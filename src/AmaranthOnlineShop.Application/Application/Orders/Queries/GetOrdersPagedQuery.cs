using AmaranthOnlineShop.Application.Application.Orders.Responses;
using AmaranthOnlineShop.Application.Application.Products.Responses;
using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Application.Common.Models;
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
    public class GetOrdersPagedQuery : IRequest<PaginatedResult<OrderDetailDto>>
    {
        public OrdersPagedRequest OrdersPagedRequest { get; set; }
    }

    public class GetOrdersPagedQueryHandler : IRequestHandler<GetOrdersPagedQuery, PaginatedResult<OrderDetailDto>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetOrdersPagedQueryHandler(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PaginatedResult<OrderDetailDto>> Handle(GetOrdersPagedQuery request,
            CancellationToken cancellationToken)
        {
            var pagedProductsDto = await _repository.GetPagedData<OrderDetail, OrderDetailDto>(request.OrdersPagedRequest);
            return pagedProductsDto;
        }
    }
}
