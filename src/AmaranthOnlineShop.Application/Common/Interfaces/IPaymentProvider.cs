namespace AmaranthOnlineShop.Application.Common.Interfaces
{
    public interface IPaymentProvider
    {
        string CreateCheckoutSession(decimal total, int orderId, string domain);
    }
}