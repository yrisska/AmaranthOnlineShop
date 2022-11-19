using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Application.Common.Models;
using AmaranthOnlineShop.Domain;
using AutoMapper;
using MediatR;

namespace AmaranthOnlineShop.Application.Application.ProductCategories.Queries
{
    public class GetPagedProductCategoriesQuery : IRequest<PaginatedResult<ProductCategoryPagedDto>>
    {
        public ProductCategoriesPagedRequest ProductCategoriesPagedRequest { get; set; }
    }

    public class GetAllProductCategoriesQueryHandler : IRequestHandler<GetPagedProductCategoriesQuery, PaginatedResult<ProductCategoryPagedDto>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProductCategoriesQueryHandler(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PaginatedResult<ProductCategoryPagedDto>> Handle(GetPagedProductCategoriesQuery request, CancellationToken cancellationToken)
        {
            var productCategoriesPagedDto =
                await _repository.GetPagedData<ProductCategory, ProductCategoryPagedDto>(request.ProductCategoriesPagedRequest);

            return productCategoriesPagedDto;
        }
    }

    public class ProductCategoryPagedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUri { get; set; }
    }
}