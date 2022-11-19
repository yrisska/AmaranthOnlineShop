namespace AmaranthOnlineShop.Domain
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int ProductCategoryId { get; set; }
        public string ImageUri { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}