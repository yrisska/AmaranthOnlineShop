using AmaranthOnlineShop.Application.Application.Orders.Commands;
using AmaranthOnlineShop.Application.Application.Orders.Queries;
using AmaranthOnlineShop.Domain;
using AutoMapper;

namespace AmaranthOnlineShop.Application.Application.Profiles
{
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<MakeOrderCommand, OrderDetail>();
            CreateMap<OrderDetail, OrderDetailDto>();
            CreateMap<OrderDetail, OrderDetailPagedDto>();
        }
    }
}