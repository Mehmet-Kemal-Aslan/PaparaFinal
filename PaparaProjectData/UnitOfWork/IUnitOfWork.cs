using PaparaFinalData.Entity;
using PaparaProjectData.GenericRepository.GenericRepositoryBaseEntity;
using PaparaProjectData.GenericRepository.GenericRepositoryIdentityUser;

namespace PaparaProjectData.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task Complete();
        Task CompleteWithTransaction();
        IGenericReadRepositoryIdentityUser<User> UserReadRepository { get; }
        IGenericWriteRepositoryIdentityUser<User> UserWriteRepository { get; }
        IGenericReadRepositoryBaseEntity<Wallet> WalletReadRepository { get; }
        IGenericWriteRepositoryBaseEntity<Wallet> WalletWriteRepository { get; }
        IGenericReadRepositoryBaseEntity<Category> CategoryReadRepository { get; }
        IGenericWriteRepositoryBaseEntity<Category> CategoryWriteRepository { get; }
        IGenericReadRepositoryBaseEntity<Coupon> CouponReadRepository { get; }
        IGenericWriteRepositoryBaseEntity<Coupon> CouponWriteRepository { get; }
        IGenericReadRepositoryBaseEntity<Product> ProductReadRepository { get; }
        IGenericWriteRepositoryBaseEntity<Product> ProductWriteRepository { get; }
    }
}
