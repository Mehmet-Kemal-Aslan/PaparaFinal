using PaparaFinalData.Entity;
using PaparaProjectData.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Helpers.PurchaseHelper
{
    public class BuyWithWallet
    {
        private readonly IUnitOfWork unitOfWork;

        public BuyWithWallet(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<decimal> CheckWallet(Wallet wallet, decimal price)
        {
            decimal money = wallet.Money;
            decimal balance = price - money;

            if (balance < 0)
            {
                wallet.Money = balance * (-1);
                unitOfWork.WalletWriteRepository.Update(wallet);
                unitOfWork.Complete();
                return 0;
            }

            return balance;
        }
    }
}
