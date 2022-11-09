using AmaranthOnlineShop.Application.Application.Orders.Commands;
using AmaranthOnlineShop.Application.Application.Orders.Queries;
using AmaranthOnlineShop.Domain;
using AutoMapper;
using System.Security.Cryptography.X509Certificates;

namespace AmaranthOnlineShop.Application.Application.Profiles
{
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<MakeOrderCommand, OrderDetail>();
            CreateMap<OrderDetail, OrderDetailDto>();
            CreateMap<OrderDetail, OrderDetailListDto>();
            CreateMap<OrderDetail, OrderDetailPagedDto>();
        }
    }
}
