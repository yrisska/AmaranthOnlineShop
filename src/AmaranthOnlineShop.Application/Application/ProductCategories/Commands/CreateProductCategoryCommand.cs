using AmaranthOnlineShop.Application.Application.ProductCategories.Responses;
using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Domain;
using AutoMapper;
using MediatR;

namespace AmaranthOnlineShop.Application.Application.ProductCategories.Commands
{
    public class CreateProductCategoryCommand : IRequest<ProductCategoryDto>
    {
        public string Name { get; set; }
    }

    public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, ProductCategoryDto>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public CreateProductCategoryCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductCategoryDto> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<ProductCategory>(request);
            _repository.Add(category);
            await _repository.SaveChangesAsync();

            var categoryDto = _mapper.Map<ProductCategoryDto>(category);
            return categoryDto;
        }
    }
}
