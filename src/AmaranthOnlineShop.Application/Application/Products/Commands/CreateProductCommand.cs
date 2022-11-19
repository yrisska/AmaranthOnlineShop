using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Domain;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AmaranthOnlineShop.Application.Application.Products.Commands
{
    public class CreateProductCommand : IRequest<ProductCreatedDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int ProductCategoryId { get; set; }
        public IFormFile? ImageFile { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductCreatedDto>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICloudStorage _cloudStorage;

        public CreateProductCommandHandler(IRepository repository, IMapper mapper, ICloudStorage cloudStorage)
        {
            _repository = repository;
            _mapper = mapper;
            _cloudStorage = cloudStorage;
        }

        public async Task<ProductCreatedDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            _repository.Add(product);

            await _repository.SaveChangesAsync();

            if (request.ImageFile != null)
            {
                product.ImageUri = await _cloudStorage.UploadAsync(
                    request.ImageFile,
                    product.Id + Path.GetExtension(request.ImageFile.FileName)
                );
            }
            else
            {
                product.ImageUri = _cloudStorage.Placeholder;
            }

            await _repository.SaveChangesAsync();

            return _mapper.Map<ProductCreatedDto>(product);
        }
    }
    public class ProductCreatedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUri { get; set; }
        public int ProductCategoryId { get; set; }
    }
}