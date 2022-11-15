using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Domain;
using AutoMapper;
using MediatR;

namespace AmaranthOnlineShop.Application.Application.ProductCategories.Queries
{
    public class GetAllProductCategoriesQuery : IRequest<IEnumerable<ProductCategoryListDto>>
    {

    }

    public class GetAllProductCategoriesQueryHandler : IRequestHandler<GetAllProductCategoriesQuery, IEnumerable<ProductCategoryListDto>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProductCategoriesQueryHandler(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<ProductCategoryListDto>> Handle(GetAllProductCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categoriesList = await _repository.GetAll<ProductCategory>();
            var categoriesDtoList = _mapper.Map<List<ProductCategoryListDto>>(categoriesList);
            return categoriesDtoList;
        }
    }
    public class ProductCategoryListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUri { get; set; }
    }
}
