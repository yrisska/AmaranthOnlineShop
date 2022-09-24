namespace AmaranthOnlineShop.Domain
{
    public class OrderDetail : BaseEntity
    {
        public decimal Total { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public int PaymentDetailId { get; set; }
        public PaymentDetail PaymentDetail { get; set; }

    }
}
