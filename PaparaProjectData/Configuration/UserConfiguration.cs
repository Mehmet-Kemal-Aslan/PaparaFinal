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

            builder.HasMany(u => u.Invoices)
                   .WithOne(w => w.Users)
                   .HasForeignKey(w => w.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.AspNetUserClaims)
                   .WithOne()
                   .HasForeignKey(w => w.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.AspNetUserTokens)
                   .WithOne()
                   .HasForeignKey(w => w.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.AspNetUserLogins)
                   .WithOne()
                   .HasForeignKey(w => w.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.AspNetUserRoles)
                   .WithOne()
                   .HasForeignKey(w => w.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
