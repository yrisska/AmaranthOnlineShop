using AutoMapper;
using AmaranthOnlineShop.Domain;
using AmaranthOnlineShop.Application.Application.ProductCategories.Commands;
using AmaranthOnlineShop.Application.Application.ProductCategories.Queries;

namespace AmaranthOnlineShop.Application.Application.Profiles
{
    public class ProductCategoryProfile : Profile
    {
        public ProductCategoryProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDto>();
            CreateMap<ProductCategory, ProductCategoryListDto>();
            CreateMap<CreateProductCategoryCommand, ProductCategory>();
            CreateMap<UpdateProductCategoryCommand, ProductCategory>();
        }
    }
}
