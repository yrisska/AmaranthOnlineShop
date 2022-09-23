﻿using AmaranthOnlineShop.Application.Application.Products.Responses;
using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Domain;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaranthOnlineShop.Application.Application.Products.Queries
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public int ProductId { get; set; }
    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public GetProductByIdQueryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product =
                await _repository.GetByIdWithInclude<Product>(request.ProductId, product => product.ProductCategory);
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }
    }
}
