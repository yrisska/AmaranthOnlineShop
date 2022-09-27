using AutoMapper;
using AmaranthOnlineShop.Domain;
using AmaranthOnlineShop.Application.Application.Products.Responses;
using AmaranthOnlineShop.Application.Application.Products.Commands;
using AmaranthOnlineShop.Application.Common.Models;
using System.Text;

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
            CreateMap<Product, ProductListDto>()
                .ForMember(x => x.ProductCategory,
                    y =>
                        y.MapFrom(z => z.ProductCategory.Name));

            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();

            CreateMap<ProductPagedRequest, PagedRequest>()
                .ForMember(x => x.RequestFilters,
                    y =>
                        y.MapFrom(z => z.RequestFilters));
        }
    }
}
