using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaranthOnlineShop.Domain
{
    public class CartItem : BaseEntity
    {
        public int ShoppingSessionId { get; set; }
        public ShoppingSession ShoppingSession { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
