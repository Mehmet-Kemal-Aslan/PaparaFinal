using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaparaFinalData.Entity;

namespace PaparaFinalData.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(b => b.IsActive).IsRequired(true);

            builder.Property(p => p.Name).IsRequired(true).HasMaxLength(100);
            builder.Property(p => p.Features).IsRequired(false).HasMaxLength(1000);
            builder.Property(p => p.Description).IsRequired(false).HasMaxLength(2000);
            builder.Property(p => p.Stock).IsRequired(true);
            builder.Property(p => p.Price).IsRequired(true);
            builder.Property(p => p.PointMultiplierPercentage).IsRequired(true);
            builder.Property(p => p.IsActive).IsRequired(true);

            builder.HasMany(p => p.ProductCategoryMaps)
                   .WithOne(pcm => pcm.Products)
                   .HasForeignKey(pcm => pcm.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.BasketItems)
                   .WithOne(x => x.Products)
                   .HasForeignKey(x => x.ProductId);
        }
    }
}
