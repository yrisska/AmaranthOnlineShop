using AmaranthOnlineShop.Application.Common.Interfaces;
using Stripe;
using Stripe.Checkout;

namespace AmaranthOnlineShop.Infrastructure.Payment
{
    public class StripePaymentProvider : IPaymentProvider
    {
        public string CreateCheckoutSession(decimal total, int orderId, string domain)
        {
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmountDecimal = decimal.Multiply(total, 100),
                            Currency = "USD",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = "Amaranth Online Shop Order"
                            }
                        },
                        Quantity = 1,
                    },
                },
                Mode = "payment",
                SuccessUrl = domain + "/shop",
                CancelUrl = domain + "/",
                Metadata = new()
                {
                    {"orderId", orderId.ToString()}
                },
                PaymentIntentData = new SessionPaymentIntentDataOptions
                {
                    Metadata = new()
                    {
                        {"orderId", orderId.ToString()}
                    },
                }
            };
            var service = new SessionService();
            Session session = service.Create(options);
            return session.Url;
        }
    }
}