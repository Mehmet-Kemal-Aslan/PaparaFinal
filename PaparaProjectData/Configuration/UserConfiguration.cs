using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaparaFinalData.Entity;

namespace PaparaFinalData.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Name).IsRequired(true).HasMaxLength(100);
            builder.Property(u => u.Surname).IsRequired(true).HasMaxLength(100);
            builder.Property(u => u.UserName).IsRequired(true).HasMaxLength(100);
            builder.Property(u => u.Email).IsRequired(true).HasMaxLength(100);
            builder.Property(u => u.Password).IsRequired(true).HasMaxLength(100);
            builder.Property(u => u.PhoneNumber).IsRequired(true).HasMaxLength(15);
            builder.Property(u => u.Role).IsRequired(true).HasMaxLength(50);
            builder.Property(u => u.Point).IsRequired(false);
            builder.Property(u => u.Address).IsRequired(true);

            builder.HasMany(u => u.Wallets)
                   .WithOne(w => w.Users)
                   .HasForeignKey(w => w.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Baskets)
                   .WithOne(w => w.Users)
                   .HasForeignKey(w => w.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Orders)
                   .WithOne(w => w.Users)
                   .HasForeignKey(w => w.UserId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

