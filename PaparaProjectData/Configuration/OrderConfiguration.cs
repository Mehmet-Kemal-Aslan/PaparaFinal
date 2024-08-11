using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaparaFinalData.Entity;

namespace PaparaFinalData.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(b => b.IsActive).IsRequired(true);

            builder.Property(o => o.UserId).IsRequired(true);
            builder.Property(o => o.Description).IsRequired(false).HasMaxLength(2000);
            builder.Property(o => o.Price).IsRequired(true);
            builder.Property(o => o.CouponPrice).IsRequired(false);
            builder.Property(o => o.CouponCode).IsRequired(false);
            builder.Property(o => o.Point).IsRequired(false);
            builder.Property(o => o.Address).IsRequired(true).HasMaxLength(500);
            builder.Property(o => o.DateTime).IsRequired(true);
            builder.Property(o => o.BasketId).IsRequired(false);

            builder.HasMany(o => o.OrderDetails)
                   .WithOne(od => od.Orders)
                   .HasForeignKey(o => o.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.Baskets)
                   .WithOne(b => b.Orders)
                   .HasForeignKey<Order>(o => o.BasketId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(o => o.Users)
                   .WithMany(u => u.Orders)
                   .HasForeignKey(od => od.UserId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
