using AmaranthOnlineShop.Application.Application.Cart.Responses;
using AmaranthOnlineShop.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaranthOnlineShop.Application.Application.Profiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<ShoppingSession, ShoppingSessionDto>();
        }
    }
}
