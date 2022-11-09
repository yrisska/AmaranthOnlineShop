using AutoMapper;
using AmaranthOnlineShop.Domain;
using AmaranthOnlineShop.Application.Application.Products.Commands;
using AmaranthOnlineShop.Application.Common.Models;
using AmaranthOnlineShop.Application.Application.Products.Queries;

namespace AmaranthOnlineShop.Application.Application.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(x => x.ProductCategoryId,
                    y =>
                        y.MapFrom(z => z.ProductCategoryId));
            CreateMap<Product, ProductPagedDto>()
                .ForMember(x => x.ProductCategory,
                    y =>
                        y.MapFrom(z => z.ProductCategory.Name));

            CreateMap<CreateProductCommand, Product>();
            
            CreateMap<int?, int>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<decimal?, decimal>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<UpdateProductCommand, Product>()
                .ForAllMembers(options => options
                    .Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ProductPagedRequest, PagedRequest>()
                .ForMember(x => x.RequestFilters,
                    y =>
                        y.MapFrom(z => z.RequestFilters));
        }
    }
}
