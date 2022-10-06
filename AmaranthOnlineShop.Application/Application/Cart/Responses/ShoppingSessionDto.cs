using AmaranthOnlineShop.Application.Application.Products.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AmaranthOnlineShop.Application.Application.Cart.Responses
{
    public class ShoppingSessionDto
    {
        [JsonIgnore]
        public string sessionId { get; set; }
        public decimal Total { get; set; }
        public IList<ProductDto> Products { get; set; }
    }
}
