﻿using AmaranthOnlineShop.Application.Application.Products.Responses;
using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Application.Common.Models;
using AmaranthOnlineShop.Domain;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AmaranthOnlineShop.Application.Application.ProductCategories.Queries
{
    public class GetAllProductCategoriesQuery : IRequest<IEnumerable<ProductCategoryDto>>
    {
        public PagedRequest PagedRequest { get; set; }
    }

    public class GetAllProductCategoriesQueryHandler : IRequestHandler<GetAllProductCategoriesQuery, IEnumerable<ProductCategoryDto>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProductCategoriesQueryHandler(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<ProductCategoryDto>> Handle(GetAllProductCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categoriesList = await _repository.GetAll<ProductCategory>();
            var categoriesDtoList = _mapper.Map<List<ProductCategoryDto>>(categoriesList);
            return categoriesDtoList;
        }
    }
}