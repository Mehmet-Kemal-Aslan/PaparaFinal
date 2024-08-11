using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaparaFinalData.Entity;

namespace PaparaFinalData.Configuration
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.Property(b => b.IsActive).IsRequired(true);

            builder.Property(x => x.OrderId).IsRequired(true);

            builder.HasOne(od => od.Orders)
                   .WithMany(o => o.OrderDetails)
                   .HasForeignKey(od => od.OrderId);

            builder.HasMany(od => od.BasketItems)
                   .WithOne(bi => bi.OrderDetails)
                   .HasForeignKey(bi => bi.OrderDetailId);
        }
    }
}
