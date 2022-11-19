using AmaranthOnlineShop.Application.Common.Exceptions;
using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Domain;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AmaranthOnlineShop.Application.Application.ProductCategories.Commands
{
    public class UpdateProductCategoryCommand : IRequest<ProductCategoryUpdatedDto>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IFormFile? ImageFile { get; set; }
    }

    public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommand, ProductCategoryUpdatedDto>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICloudStorage _cloudStorage;

        public UpdateProductCategoryCommandHandler(IRepository repository, IMapper mapper, ICloudStorage cloudStorage)
        {
            _repository = repository;
            _mapper = mapper;
            _cloudStorage = cloudStorage;
        }

        public async Task<ProductCategoryUpdatedDto> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetById<ProductCategory>(request.Id) ??
                           throw new EntityNotFoundException("Entity with specified id not found");
            _mapper.Map(request, category);
            await _repository.SaveChangesAsync();

            if (request.ImageFile != null)
            {
                category.ImageUri = await _cloudStorage.UploadAsync(
                    request.ImageFile,
                    "category" + category.Id + Path.GetExtension(request.ImageFile.FileName)
                );
            }

            await _repository.SaveChangesAsync();

            return _mapper.Map<ProductCategoryUpdatedDto>(category);
        }
    }

    public class ProductCategoryUpdatedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUri { get; set; }
    }
}