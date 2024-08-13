using Microsoft.EntityFrameworkCore;
using PaparaFinalData.Context;
using PaparaFinalData.Entity;
using PaparaProjectData.GenericRepository;
using PaparaProjectData.GenericRepository.GenericRepositoryBaseEntity;
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

        public IGenericReadRepositoryBaseEntity<User> UserReadRepository { get; }
        public IGenericWriteRepositoryBaseEntity<User> UserWriteRepository { get; }
        public IGenericReadRepositoryBaseEntity<Wallet> WalletReadRepository { get; }
        public IGenericWriteRepositoryBaseEntity<Wallet> WalletWriteRepository { get; }
        public IGenericReadRepositoryBaseEntity<Category> CategoryReadRepository { get; }
        public IGenericWriteRepositoryBaseEntity<Category> CategoryWriteRepository { get; }
        public IGenericReadRepositoryBaseEntity<Coupon> CouponReadRepository { get; }
        public IGenericWriteRepositoryBaseEntity<Coupon> CouponWriteRepository { get; }
        public IGenericReadRepositoryBaseEntity<Product> ProductReadRepository { get; }
        public IGenericWriteRepositoryBaseEntity<Product> ProductWriteRepository { get; }
        public IGenericReadRepositoryBaseEntity<Basket> BasketReadRepository { get; }
        public IGenericWriteRepositoryBaseEntity<Basket> BasketWriteRepository { get; }
        public IGenericReadRepositoryBaseEntity<BasketItem> BasketItemReadRepository { get; }
        public IGenericWriteRepositoryBaseEntity<BasketItem> BasketItemWriteRepository { get; }
        public IGenericReadRepositoryBaseEntity<Order> OrderReadRepository { get; }
        public IGenericWriteRepositoryBaseEntity<Order> OrderWriteRepository { get; }
        public IGenericReadRepositoryBaseEntity<OrderDetail> OrderDetailReadRepository { get; }
        public IGenericWriteRepositoryBaseEntity<OrderDetail> OrderDetailWriteRepository { get; }

        public UnitOfWork(PaparaProjectDbContext dbContext)
        {
            this.dbContext = dbContext;

            UserReadRepository = new GenericReadRepositoryBaseEntity<User>(this.dbContext);
            UserWriteRepository = new GenericWriteRepositoryBaseEntity<User>(this.dbContext);
            WalletReadRepository = new GenericReadRepositoryBaseEntity<Wallet>(this.dbContext);
            WalletWriteRepository = new GenericWriteRepositoryBaseEntity<Wallet>(this.dbContext);
            CategoryReadRepository = new GenericReadRepositoryBaseEntity<Category>(this.dbContext);
            CategoryWriteRepository = new GenericWriteRepositoryBaseEntity<Category>(this.dbContext);
            CouponReadRepository = new GenericReadRepositoryBaseEntity<Coupon>(this.dbContext);
            CouponWriteRepository = new GenericWriteRepositoryBaseEntity<Coupon>(this.dbContext);
            ProductReadRepository = new GenericReadRepositoryBaseEntity<Product>(this.dbContext);
            ProductWriteRepository = new GenericWriteRepositoryBaseEntity<Product>(this.dbContext);
            BasketReadRepository = new GenericReadRepositoryBaseEntity<Basket>(this.dbContext);
            BasketWriteRepository = new GenericWriteRepositoryBaseEntity<Basket>(this.dbContext);
            BasketItemReadRepository = new GenericReadRepositoryBaseEntity<BasketItem>(this.dbContext);
            BasketItemWriteRepository = new GenericWriteRepositoryBaseEntity<BasketItem>(this.dbContext);
            OrderReadRepository = new GenericReadRepositoryBaseEntity<Order>(this.dbContext);
            OrderWriteRepository = new GenericWriteRepositoryBaseEntity<Order>(this.dbContext);
            OrderDetailReadRepository = new GenericReadRepositoryBaseEntity<OrderDetail>(this.dbContext);
            OrderDetailWriteRepository = new GenericWriteRepositoryBaseEntity<OrderDetail>(this.dbContext);
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
