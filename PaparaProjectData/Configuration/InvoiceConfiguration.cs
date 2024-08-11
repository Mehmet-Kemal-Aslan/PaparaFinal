using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaparaFinalData.Entity;

namespace PaparaFinalData.Configuration
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(b => b.IsActive).IsRequired(true);

            builder.Property(i => i.Price).IsRequired(true);

            builder.HasOne(i => i.Users)
                   .WithMany(u => u.Invoices)
                   .HasForeignKey(i => i.UserId)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
