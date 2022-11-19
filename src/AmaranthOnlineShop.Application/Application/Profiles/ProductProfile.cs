using AmaranthOnlineShop.Application.Application.Products.Commands;
using AmaranthOnlineShop.Application.Application.Products.Queries;
using AmaranthOnlineShop.Domain;
using AutoMapper;

namespace AmaranthOnlineShop.Application.Application.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Product, ProductPagedDto>();

            CreateMap<Product, ProductCreatedDto>();
            CreateMap<Product, ProductUpdatedDto>();
            CreateMap<Product, ProductDeletedDto>();

            CreateMap<CreateProductCommand, Product>();

            //We might want to update only specific fields
            CreateMap<int?, int>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<decimal?, decimal>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<UpdateProductCommand, Product>()
                .ForAllMembers(options => options
                    .Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}