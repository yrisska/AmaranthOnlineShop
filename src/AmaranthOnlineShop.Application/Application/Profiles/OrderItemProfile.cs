using AmaranthOnlineShop.Application.Application.Orders.Queries;
using AmaranthOnlineShop.Domain;
using AutoMapper;

namespace AmaranthOnlineShop.Application.Application.Profiles
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<OrderItem, OrderItemPagedDto>();
        }
    }
}