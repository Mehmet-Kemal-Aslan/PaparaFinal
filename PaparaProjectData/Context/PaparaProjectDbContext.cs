using Microsoft.EntityFrameworkCore;
using PaparaFinalData.Configuration;
using PaparaFinalData.Entity;

namespace PaparaFinalData.Context
{
    public class PaparaProjectDbContext : DbContext
    {
        public PaparaProjectDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BasketConfiguration());
            modelBuilder.ApplyConfiguration(new BasketItemConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryMapConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CouponConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new WalletConfiguration());
        }
    }
}
