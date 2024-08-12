using PaparaFinalData.Entity;
using PaparaProjectData.UnitOfWork;

namespace PaparaProjectBusiness.Features.Helpers.PurchaseHelper
{
    public class BuyWithPoint
    {
        private readonly IUnitOfWork unitOfWork;

        public BuyWithPoint(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<decimal> CheckPoint(User user, decimal price)
        {
            decimal point = user.Point ?? 0;
            decimal balance = price - point;

            if (balance < 0)
            {
                user.Point = balance * (-1);

                unitOfWork.UserWriteRepository.Update(user);
                unitOfWork.Complete();
                return 0;
            }
                
            return balance;
        }
    }
}
