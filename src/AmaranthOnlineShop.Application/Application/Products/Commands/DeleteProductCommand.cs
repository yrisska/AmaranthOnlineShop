using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Domain;
using AutoMapper;
using MediatR;

namespace AmaranthOnlineShop.Application.Application.Products.Commands
{
    public class DeleteProductCommand : IRequest<ProductDeletedDto>
    {
        public int Id { get; set; }
    }
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ProductDeletedDto>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICloudStorage _cloudStorage;

        public DeleteProductCommandHandler(IRepository repository, IMapper mapper, ICloudStorage cloudStorage)
        {
            _repository = repository;
            _mapper = mapper;
            _cloudStorage = cloudStorage;
        }

        public async Task<ProductDeletedDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.Delete<Product>(request.Id);
            await _repository.SaveChangesAsync();

            if (product.ImageUri != _cloudStorage.Placeholder)
            {
                await _cloudStorage.DeleteAsync(Path.GetFileName(product.ImageUri));
            }

            return _mapper.Map<ProductDeletedDto>(product);
        }
    }
    public class ProductDeletedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUri { get; set; }
        public int ProductCategoryId { get; set; }
    }
}