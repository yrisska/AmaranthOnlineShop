namespace AmaranthOnlineShop.Domain
{
    public class ProductCategory : BaseEntity
    {
        public string Name { get; set; }
        public string ImageUri { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
