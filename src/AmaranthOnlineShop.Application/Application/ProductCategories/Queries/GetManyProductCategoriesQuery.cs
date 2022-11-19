using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Domain;
using AutoMapper;
using MediatR;

namespace AmaranthOnlineShop.Application.Application.ProductCategories.Queries
{
    public class GetManyProductCategoriesQuery : IRequest<IEnumerable<ProductCategoryListDto>>
    {
        public int[] Identifiers { get; set; }
    }

    public class
        GetManyProductCategoriesHandler : IRequestHandler<GetManyProductCategoriesQuery, IEnumerable<ProductCategoryListDto>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetManyProductCategoriesHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductCategoryListDto>> Handle(GetManyProductCategoriesQuery request, CancellationToken cancellationToken)
        {
            var productCategory =
                await _repository.GetRangeByIds<ProductCategory>(request.Identifiers);

            var productCategoryListDto = _mapper.Map<IEnumerable<ProductCategoryListDto>>(productCategory);

            return productCategoryListDto;
        }
    }

    public class ProductCategoryListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUri { get; set; }
    }
}