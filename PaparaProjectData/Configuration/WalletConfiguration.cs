using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaparaFinalData.Entity;

namespace PaparaFinalData.Configuration
{
    public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.Property(b => b.IsActive).IsRequired(true);

            builder.Property(w => w.Money).IsRequired(true);

            builder.HasOne(w => w.Users)
                   .WithMany(u => u.Wallets)
                   .HasForeignKey(w => w.UserId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
