using AmaranthOnlineShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmaranthOnlineShop.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(1000);
            builder.Property(x => x.Price)
                .HasPrecision(19, 4);
            builder.Property(x => x.ImageUri)
                .IsRequired(false);

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.ProductCategory)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.ProductCategoryId);

            builder.HasData(
                new Product()
                {
                    Id = 1,
                    Name = "Day gel-cream",
                    Description = "Great for day",
                    Price = 9.99m,
                    ProductCategoryId = 1,
                },
                new Product()
                {
                    Id = 2,
                    Name = "Night gel-cream",
                    Description = "Great for nigh",
                    Price = 8.99m,
                    ProductCategoryId = 1,
                },
                new Product()
                {
                    Id = 3,
                    Name = "Body cleaner",
                    Description = "Cleans well",
                    Price = 15.49m,
                    ProductCategoryId = 1,
                },
                new Product()
                {
                    Id = 4,
                    Name = "Amaranth flour",
                    Description = "Tastes well",
                    Price = 5.49m,
                    ProductCategoryId = 2,
                },
                new Product()
                {
                    Id = 5,
                    Name = "Amaranth Flakes",
                    Description = "Tastes really well",
                    Price = 6.49m,
                    ProductCategoryId = 2,
                },
                new Product()
                {
                    Id = 6,
                    Name = "Shaving Gel",
                    Description = "Shave with ease",
                    Price = 7.99m,
                    ProductCategoryId = 3,
                },
                new Product()
                {
                    Id = 7,
                    Name = "Shampoo",
                    Description = "Hair like a feather",
                    Price = 7.99m,
                    ProductCategoryId = 3,
                }
            );
        }
    }
}