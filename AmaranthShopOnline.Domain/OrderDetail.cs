using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaranthShopOnline.Domain
{
    public class OrderDetail : BaseEntity
    {
        public decimal Total { get; set; }
        public ICollection<OrderItem> OrderItems{ get; set; }
        public int PaymentDetailId{ get; set; }
        public PaymentDetail PaymentDetail { get; set; }

    }
}
