using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmaranthOnlineShop.Domain;
using AmaranthOnlineShop.Application.Application.Products.Responses;

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
        }
    }
}
