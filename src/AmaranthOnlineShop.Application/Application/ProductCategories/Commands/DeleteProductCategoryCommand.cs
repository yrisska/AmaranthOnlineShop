using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Domain;
using AutoMapper;
using MediatR;

namespace AmaranthOnlineShop.Application.Application.ProductCategories.Commands
{
    public class DeleteProductCategoryCommand : IRequest<ProductCategoryDeletedDto>
    {
        public int Id { get; set; }
    }

    public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommand, ProductCategoryDeletedDto>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public DeleteProductCategoryCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductCategoryDeletedDto> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.Delete<ProductCategory>(request.Id);
            await _repository.SaveChangesAsync();

            return _mapper.Map<ProductCategoryDeletedDto>(category);
        }
    }

    public class ProductCategoryDeletedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUri { get; set; }
    }
}