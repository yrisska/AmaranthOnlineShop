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

            builder.HasData(
                new ProductCategory{ Id = 1, Name = "Skin Care"},
                new ProductCategory { Id = 2, Name = "Meal" },
                new ProductCategory { Id = 3, Name = "Cosmetics" }
            );
        }
    }
}
