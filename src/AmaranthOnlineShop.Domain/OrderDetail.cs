namespace AmaranthOnlineShop.Domain
{
    public class OrderDetail : BaseEntity
    {
        public decimal Total { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public OrderStatus Status { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string? Comments { get; set; }
        public string? UserId { get; set; }
    }
}