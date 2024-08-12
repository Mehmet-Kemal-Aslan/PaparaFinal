using PaparaFinalData.Entity;
using PaparaProjectData.GenericRepository.GenericRepositoryBaseEntity;

namespace PaparaProjectData.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task Complete();
        Task CompleteWithTransaction();
        IGenericReadRepositoryBaseEntity<User> UserReadRepository { get; }
        IGenericWriteRepositoryBaseEntity<User> UserWriteRepository { get; }
        IGenericReadRepositoryBaseEntity<Wallet> WalletReadRepository { get; }
        IGenericWriteRepositoryBaseEntity<Wallet> WalletWriteRepository { get; }
        IGenericReadRepositoryBaseEntity<Category> CategoryReadRepository { get; }
        IGenericWriteRepositoryBaseEntity<Category> CategoryWriteRepository { get; }
        IGenericReadRepositoryBaseEntity<Coupon> CouponReadRepository { get; }
        IGenericWriteRepositoryBaseEntity<Coupon> CouponWriteRepository { get; }
        IGenericReadRepositoryBaseEntity<Product> ProductReadRepository { get; }
        IGenericWriteRepositoryBaseEntity<Product> ProductWriteRepository { get; }
        IGenericReadRepositoryBaseEntity<Basket> BasketReadRepository { get; }
        IGenericWriteRepositoryBaseEntity<Basket> BasketWriteRepository { get; }
        IGenericReadRepositoryBaseEntity<BasketItem> BasketItemReadRepository { get; }
        IGenericWriteRepositoryBaseEntity<BasketItem> BasketItemWriteRepository { get; }
    }
}
