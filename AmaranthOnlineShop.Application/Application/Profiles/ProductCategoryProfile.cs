using AutoMapper;
using AmaranthOnlineShop.Domain;
using AmaranthOnlineShop.Application.Application.ProductCategories.Responses;

namespace AmaranthOnlineShop.Application.Application.Profiles
{
    public class ProductCategoryProfile : Profile
    {
        public ProductCategoryProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDto>();
        }
    }
}
