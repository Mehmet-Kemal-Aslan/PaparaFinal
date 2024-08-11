using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaparaFinalData.Entity;

namespace PaparaFinalData.Configuration
{
    public class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.Property(b => b.IsActive).IsRequired(true);

            builder.Property(b => b.UserId).IsRequired(true);
            builder.Property(b => b.OrderId).IsRequired(false);

            builder.HasOne(b => b.Users)
                   .WithMany(b => b.Baskets)
                   .HasForeignKey(b => b.UserId)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(b => b.Orders)
                   .WithOne(o => o.Baskets)
                   .HasForeignKey<Basket>(x => x.OrderId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(b => b.BasketItems)
                   .WithOne(bi => bi.Baskets)
                   .HasForeignKey(bi => bi.BasketId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
