using AmaranthOnlineShop.Application.Application.Products.Responses;
using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Application.Common.Models;
using AmaranthOnlineShop.Domain;
using AutoMapper;
using MediatR;

namespace AmaranthOnlineShop.Application.Application.Products.Queries
{
    public class GetProductsPagedQuery : IRequest<PaginatedResult<ProductListDto>>
    {
        public ProductPagedRequest ProductPagedRequest { get; set; }
    }

    public class GetProductsPagedQueryHandler : IRequestHandler<GetProductsPagedQuery, PaginatedResult<ProductListDto>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public GetProductsPagedQueryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<ProductListDto>> Handle(GetProductsPagedQuery request, CancellationToken cancellationToken)
        {
            var pagedRequest = _mapper.Map<PagedRequest>(request.ProductPagedRequest);
            var pagedProductsDto = await _repository.GetPagedData<Product, ProductListDto>(pagedRequest);
            return pagedProductsDto;
        }
    }
}
