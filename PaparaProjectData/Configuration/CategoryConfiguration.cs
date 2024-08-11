using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaparaFinalData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaFinalData.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(b => b.IsActive).IsRequired(true);

            builder.Property(c => c.Name).IsRequired(true).HasMaxLength(100);
            builder.Property(c => c.Url).IsRequired(true).HasMaxLength(200);
            builder.Property(c => c.Tags).IsRequired(false).HasMaxLength(500);

            builder.HasMany(c => c.ProductCategoryMaps)
                   .WithOne(pcm => pcm.Categories)
                   .HasForeignKey(pcm => pcm.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
