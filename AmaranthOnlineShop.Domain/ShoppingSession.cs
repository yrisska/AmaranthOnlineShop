using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaranthOnlineShop.Domain
{
    public class ShoppingSession : BaseEntity
    {
        public string SessionId { get; set; }
        public decimal Total { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
