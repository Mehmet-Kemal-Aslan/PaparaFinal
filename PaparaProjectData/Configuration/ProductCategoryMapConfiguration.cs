using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaparaFinalData.Entity;

namespace PaparaFinalData.Configuration
{
    public class ProductCategoryMapConfiguration : IEntityTypeConfiguration<ProductCategoryMap>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryMap> builder)
        {
            builder.Property(b => b.IsActive).IsRequired(true);

            builder.HasOne(pcm => pcm.Categories)
                   .WithMany(c => c.ProductCategoryMaps)
                   .HasForeignKey(pcm => pcm.CategoryId);

            builder.HasOne(pcm => pcm.Products)
                   .WithMany(p => p.ProductCategoryMaps)
                   .HasForeignKey(pcm => pcm.ProductId);
        }
    }
}
