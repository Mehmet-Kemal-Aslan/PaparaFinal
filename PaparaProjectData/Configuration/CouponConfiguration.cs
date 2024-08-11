using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaparaFinalData.Entity;

namespace PaparaFinalData.Configuration
{
    public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.Property(b => b.IsActive).IsRequired(true);

            builder.Property(c => c.Code).IsRequired(true).HasMaxLength(10);
            builder.Property(c => c.Price).IsRequired(true);
            builder.Property(c => c.ExpireDate).IsRequired(true);
            builder.Property(c => c.IsActive).IsRequired(true);
            builder.HasIndex(c => c.Code).IsUnique(true);
        }
    }
}
