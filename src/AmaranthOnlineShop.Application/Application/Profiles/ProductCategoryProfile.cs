using AmaranthOnlineShop.Application.Application.ProductCategories.Commands;
using AmaranthOnlineShop.Application.Application.ProductCategories.Queries;
using AmaranthOnlineShop.Domain;
using AutoMapper;

namespace AmaranthOnlineShop.Application.Application.Profiles
{
    public class ProductCategoryProfile : Profile
    {
        public ProductCategoryProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDto>();
            CreateMap<ProductCategory, ProductCategoryPagedDto>();
            CreateMap<ProductCategory, ProductCategoryListDto>();

            CreateMap<ProductCategory, ProductCategoryCreatedDto>();
            CreateMap<ProductCategory, ProductCategoryDeletedDto>();
            CreateMap<ProductCategory, ProductCategoryUpdatedDto>();

            CreateMap<CreateProductCategoryCommand, ProductCategory>();
            CreateMap<UpdateProductCategoryCommand, ProductCategory>();
        }
    }
}