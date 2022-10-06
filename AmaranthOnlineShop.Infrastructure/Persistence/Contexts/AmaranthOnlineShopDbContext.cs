using AmaranthOnlineShop.Domain;
using AmaranthOnlineShop.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AmaranthOnlineShop.Infrastructure.Persistence.Contexts
{
    public class AmaranthOnlineShopDbContext : DbContext
    {
        public AmaranthOnlineShopDbContext(DbContextOptions<AmaranthOnlineShopDbContext> options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var assembly = typeof(ProductConfiguration).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}