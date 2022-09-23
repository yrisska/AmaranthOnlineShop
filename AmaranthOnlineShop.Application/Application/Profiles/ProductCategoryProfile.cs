using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmaranthOnlineShop.Domain;
using AmaranthOnlineShop.Application.Application.Products.Responses;
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
