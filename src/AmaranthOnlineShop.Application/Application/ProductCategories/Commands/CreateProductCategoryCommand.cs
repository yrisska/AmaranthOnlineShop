using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Domain;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AmaranthOnlineShop.Application.Application.ProductCategories.Commands
{
    public class CreateProductCategoryCommand : IRequest<ProductCategoryCreatedDto>
    {
        public string Name { get; set; }
        public IFormFile? ImageFile { get; set; }
    }

    public class
        CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, ProductCategoryCreatedDto>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICloudStorage _cloudStorage;

        public CreateProductCategoryCommandHandler(IRepository repository, IMapper mapper, ICloudStorage cloudStorage)
        {
            _repository = repository;
            _mapper = mapper;
            _cloudStorage = cloudStorage;
        }

        public async Task<ProductCategoryCreatedDto> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<ProductCategory>(request);
            _repository.Add(category);
            await _repository.SaveChangesAsync();

            if (request.ImageFile != null)
            {
                category.ImageUri = await _cloudStorage.UploadAsync(
                    request.ImageFile,
                    "category" + category.Id + Path.GetExtension(request.ImageFile.FileName)
                );
            }
            else
            {
                category.ImageUri = _cloudStorage.Placeholder;
            }

            await _repository.SaveChangesAsync();

            return _mapper.Map<ProductCategoryCreatedDto>(category);
        }
    }

    public class ProductCategoryCreatedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUri { get; set; }
    }
}