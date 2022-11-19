using AmaranthOnlineShop.Application.Common.Exceptions;
using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Domain;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AmaranthOnlineShop.Application.Application.Products.Commands
{
    public class UpdateProductCommand : IRequest<ProductUpdatedDto>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public IFormFile? ImageFile { get; set; }
        public int? ProductCategoryId { get; set; }
    }
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductUpdatedDto>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICloudStorage _cloudStorage;
        public UpdateProductCommandHandler(IRepository repository, IMapper mapper, ICloudStorage cloudStorage)
        {
            _repository = repository;
            _mapper = mapper;
            _cloudStorage = cloudStorage;
        }
        public async Task<ProductUpdatedDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetById<Product>(request.Id) ??
                          throw new EntityNotFoundException("Entity with specified id not found");
            _mapper.Map(request, product);

            await _repository.SaveChangesAsync();

            if (request.ImageFile != null)
            {
                product.ImageUri = await _cloudStorage.UploadAsync(
                    request.ImageFile,
                    product.Id + Path.GetExtension(request.ImageFile.FileName)
                );
            }

            await _repository.SaveChangesAsync();

            return _mapper.Map<ProductUpdatedDto>(product);
        }
    }
    public class ProductUpdatedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUri { get; set; }
        public int ProductCategoryId { get; set; }
    }
}