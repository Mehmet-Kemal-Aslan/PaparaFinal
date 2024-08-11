using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaparaFinalData.Entity;

namespace PaparaFinalData.Configuration
{
    public class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            builder.Property(b => b.IsActive).IsRequired(true);

            builder.Property(bi => bi.Quantity).IsRequired(true);
            builder.Property(bi => bi.BasketId).IsRequired(true);
            builder.Property(bi => bi.ProductId).IsRequired(true);

            builder.HasOne(bi => bi.Baskets)
                   .WithMany(b => b.BasketItems)
                   .HasForeignKey(bi => bi.BasketId)
                   .IsRequired(true);

            builder.HasOne(bi => bi.Products)
                   .WithMany(p => p.BasketItems)
                   .HasForeignKey(x => x.ProductId)
                   .IsRequired(true);
        }
    }
}
