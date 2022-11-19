using AmaranthOnlineShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmaranthOnlineShop.Infrastructure.Persistence.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.Property(x => x.Status)
                .HasConversion<string>()
                .HasMaxLength(40);

            builder.Property(x => x.Adress)
                .HasMaxLength(200);
            builder.Property(x => x.FullName)
                .HasMaxLength(200);
            builder.Property(x => x.Email)
                .HasMaxLength(50);
            builder.Property(x => x.Phone)
                .HasMaxLength(20);
            builder.Property(x => x.Comments)
                .IsRequired(false)
                .HasMaxLength(1000);
            builder.Property(x => x.UserId)
                .IsRequired(false);
            builder.Property(x => x.Total)
                .HasPrecision(19, 4);

            builder.HasMany(x => x.OrderItems)
                .WithOne(x => x.OrderDetail)
                .HasForeignKey(x => x.OrderDetailId);
        }
    }
}