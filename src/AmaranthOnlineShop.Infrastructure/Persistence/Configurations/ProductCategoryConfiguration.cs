using AmaranthOnlineShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmaranthOnlineShop.Infrastructure.Persistence.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.ImageUri)
                .IsRequired(false);
            

            builder.HasData(
                new ProductCategory
                {
                    Id = 1, Name = "Skin Care", ImageUri = "https://yrisska.blob.core.windows.net/images/category1.jpg"
                },
                new ProductCategory
                    {Id = 2, Name = "Meal", ImageUri = "https://yrisska.blob.core.windows.net/images/category2.webp"},
                new ProductCategory
                {
                    Id = 3, Name = "Cosmetics", ImageUri = "https://yrisska.blob.core.windows.net/images/category3.jpg"
                }
            );
        }
    }
}