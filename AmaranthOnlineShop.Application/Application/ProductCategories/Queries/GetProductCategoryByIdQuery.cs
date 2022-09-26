using AmaranthOnlineShop.Application.Application.ProductCategories.Responses;
using AmaranthOnlineShop.Application.Common.Interfaces;
using AutoMapper;
using MediatR;

namespace AmaranthOnlineShop.Application.Application.ProductCategories.Queries
{
    public class GetProductCategoryByIdQuery : IRequest<ProductCategoryDto>
    {
        public int ProductCategoryId { get; set; }
    }

    public class GetProductCategoryByIdQueryHandler : IRequestHandler<GetProductCategoryByIdQuery, ProductCategoryDto>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public GetProductCategoryByIdQueryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductCategoryDto> Handle(GetProductCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var productCategory =
                await _repository.GetById<Domain.ProductCategory>(request.ProductCategoryId);
            var productCategoryDto = _mapper.Map<ProductCategoryDto>(productCategory);
            return productCategoryDto;
        }
    }
}
