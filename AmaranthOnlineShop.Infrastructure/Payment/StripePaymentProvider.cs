using AmaranthOnlineShop.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaranthOnlineShop.Infrastructure.Payment
{
    public class StripePaymentProvider : IPaymentProvider
    {
        public  string CreateCheckoutSession(decimal total, int orderId)
        {
            return "https://www.google.com/";
        }
    }
}
