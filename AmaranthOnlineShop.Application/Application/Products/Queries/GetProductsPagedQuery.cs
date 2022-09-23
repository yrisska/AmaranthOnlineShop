﻿using AmaranthOnlineShop.Application.Application.Products.Responses;
using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Application.Common.Models;
using AmaranthOnlineShop.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AmaranthOnlineShop.Application.Application.Products.Queries
{
    public class GetProductsPagedQuery : IRequest<PaginatedResult<ProductListDto>>
    {
        public PagedRequest PagedRequest { get; set; }
    }

    public class GetProductsPagedQueryHandler : IRequestHandler<GetProductsPagedQuery, PaginatedResult<ProductListDto>>
    {
        private readonly IRepository _repository;

        public GetProductsPagedQueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedResult<ProductListDto>> Handle(GetProductsPagedQuery request, CancellationToken cancellationToken)
        {
            var pagedProductsDto = await _repository.GetPagedData<Product, ProductListDto>(request.PagedRequest);
            return pagedProductsDto;
        }
    }
}