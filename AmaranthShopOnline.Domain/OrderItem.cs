using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaranthShopOnline.Domain
{
    public class OrderItem : BaseEntity
    {
        public int OrderDetailId { get; set; }
        public OrderDetail OrderDetail { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
