using AmaranthOnlineShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaranthOnlineShop.Application.Application.Orders.Responses
{
    public class OrderDetailDto
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; }
        public OrderStatus Status { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Comments { get; set; }
    }
}
