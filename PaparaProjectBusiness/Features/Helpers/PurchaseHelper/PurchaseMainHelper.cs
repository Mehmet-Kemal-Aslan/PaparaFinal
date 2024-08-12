using Azure.Core;
using PaparaFinalData.Entity;
using PaparaProjectBusiness.Features.Helpers.PurchaseHelper.Model;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Requests;

namespace PaparaProjectBusiness.Features.Helpers.PurchaseHelper
{
    public class PurchaseMainHelper
    {
        private readonly IUnitOfWork unitOfWork;

        public PurchaseMainHelper(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<PurchaseMainHelperResppnse> Purchase(PurchaseRequest purchaseRequest)
        {
            PurchaseMainHelperResppnse purchaseResponse = new PurchaseMainHelperResppnse { isPurchased = true, MoneytoCalculatePoint = 0 };
            Basket basket = await unitOfWork.BasketReadRepository.FirstOrDefault(b => b.Id == purchaseRequest.BasketId);
            decimal basketPrice = basket.Price;
            BuyWithCoupon buyWithCoupon = new BuyWithCoupon(unitOfWork);
            decimal balance = await buyWithCoupon.CheckCoupon(purchaseRequest.CouponCode, basketPrice);
            if (balance == 0)
                return purchaseResponse;

            User user = await unitOfWork.UserReadRepository.FirstOrDefault(u => u.Id == purchaseRequest.UserId);
            decimal point = user.Point ?? 0;
            BuyWithPoint buyWithPoint = new BuyWithPoint(unitOfWork);
            balance = await buyWithPoint.CheckPoint(user, balance);
            if (balance == 0)
                return purchaseResponse;

            purchaseResponse.MoneytoCalculatePoint = balance;
            Wallet wallet = await unitOfWork.WalletReadRepository.FirstOrDefault(w => w.UserId == purchaseRequest.UserId);
            decimal walletMoney = wallet.Money;
            BuyWithWallet buyWithWallet = new BuyWithWallet(unitOfWork);
            balance = await buyWithWallet.CheckWallet(wallet, balance);
            if (balance == 0)
                return purchaseResponse;
            
            BuyWithCreditCard buyWithCreditCard = new BuyWithCreditCard();
            purchaseResponse.isPurchased = await buyWithCreditCard.CheckCreditCard(purchaseRequest.CardExpireDate, purchaseRequest.CVV);

            return purchaseResponse;
        }
    }
}
