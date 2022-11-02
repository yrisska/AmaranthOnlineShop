namespace AmaranthOnlineShop.Domain
{
    public class OrderItem : BaseEntity
    {
        public int OrderDetailId { get; set; }
        public OrderDetail OrderDetail { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
