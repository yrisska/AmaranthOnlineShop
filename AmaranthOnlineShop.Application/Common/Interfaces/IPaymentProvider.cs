using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaranthOnlineShop.Application.Common.Interfaces
{
    public interface IPaymentProvider
    {
        Task<string> CreateCheckoutSession(decimal total, int orderId);
    }
}
