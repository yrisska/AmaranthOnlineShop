using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaranthOnlineShop.Domain
{
    public enum OrderStatus
    {
        OrderCancelled,
        OrderDelivered,
        OrderInTransit,
        OrderPaymentDue,
        OrderPickupAvailable,
        OrderProblem,
        OrderProcessing,
        OrderReturned
    }
}
