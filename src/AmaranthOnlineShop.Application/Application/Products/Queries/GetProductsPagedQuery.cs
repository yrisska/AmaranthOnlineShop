using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Application.Common.Models;
using AmaranthOnlineShop.Domain;
using AutoMapper;
using MediatR;

namespace AmaranthOnlineShop.Application.Application.Products.Queries
{
    public class GetProductsPagedQuery : IRequest<PaginatedResult<ProductPagedDto>>
    {
        public ProductPagedRequest ProductPagedRequest { get; set; }
    }

    public class GetProductsPagedQueryHandler : IRequestHandler<GetProductsPagedQuery, PaginatedResult<ProductPagedDto>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public GetProductsPagedQueryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<ProductPagedDto>> Handle(GetProductsPagedQuery request, CancellationToken cancellationToken)
        {
            var pagedProductsDto = await _repository.GetPagedData<Product, ProductPagedDto>(request.ProductPagedRequest);
            return pagedProductsDto;
        }
    }
    public class ProductPagedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUri { get; set; }
        public string ProductCategory { get; set; }
    }
}
