using AmaranthOnlineShop.Application.Application.Orders.Commands;
using AmaranthOnlineShop.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaranthOnlineShop.Application.Application.Profiles
{
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<MakeOrderCommand, OrderDetail>();
        }
    }
}
