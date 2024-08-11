using Microsoft.EntityFrameworkCore;
using PaparaFinalData.Context;
using PaparaFinalData.Entity;
using PaparaProjectData.GenericRepository;
using PaparaProjectData.GenericRepository.GenericRepositoryBaseEntity;
using PaparaProjectData.GenericRepository.GenericRepositoryIdentityUser;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectData.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly PaparaProjectDbContext dbContext;

        public IGenericReadRepositoryIdentityUser<User> UserReadRepository { get; }
        public IGenericWriteRepositoryIdentityUser<User> UserWriteRepository { get; }
        public IGenericReadRepositoryBaseEntity<Wallet> WalletReadRepository { get; }
        public IGenericWriteRepositoryBaseEntity<Wallet> WalletWriteRepository { get; }
        public IGenericReadRepositoryBaseEntity<Category> CategoryReadRepository { get; }
        public IGenericWriteRepositoryBaseEntity<Category> CategoryWriteRepository { get; }
        public IGenericReadRepositoryBaseEntity<Coupon> CouponReadRepository { get; }
        public IGenericWriteRepositoryBaseEntity<Coupon> CouponWriteRepository { get; }
        public IGenericReadRepositoryBaseEntity<Product> ProductReadRepository { get; }
        public IGenericWriteRepositoryBaseEntity<Product> ProductWriteRepository { get; }

        public UnitOfWork(PaparaProjectDbContext dbContext)
        {
            this.dbContext = dbContext;

            UserReadRepository = new GenericReadRepositoryIdentityUser<User>(this.dbContext);
            UserWriteRepository = new GenericWriteRepositoryIdentityUser<User>(this.dbContext);
            WalletReadRepository = new GenericReadRepositoryBaseEntity<Wallet>(this.dbContext);
            WalletWriteRepository = new GenericWriteRepositoryBaseEntity<Wallet>(this.dbContext);
            CategoryReadRepository = new GenericReadRepositoryBaseEntity<Category>(this.dbContext);
            CategoryWriteRepository = new GenericWriteRepositoryBaseEntity<Category>(this.dbContext);
            CouponReadRepository = new GenericReadRepositoryBaseEntity<Coupon>(this.dbContext);
            CouponWriteRepository = new GenericWriteRepositoryBaseEntity<Coupon>(this.dbContext);
            ProductReadRepository = new GenericReadRepositoryBaseEntity<Product>(this.dbContext);
            ProductWriteRepository = new GenericWriteRepositoryBaseEntity<Product>(this.dbContext);
        }

        public async Task Complete()
        {
            await dbContext.SaveChangesAsync();
        }

        public async Task CompleteWithTransaction()
        {
            using (var dbTransaction = await dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await dbContext.SaveChangesAsync();
                    await dbTransaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await dbTransaction.RollbackAsync();
                    Console.WriteLine(ex);
                    throw;
                }
            }
        }

        public void Dispose()
        {
        }
    }
}
