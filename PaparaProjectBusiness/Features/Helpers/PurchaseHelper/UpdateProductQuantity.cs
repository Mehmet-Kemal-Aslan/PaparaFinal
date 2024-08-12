using PaparaFinalData.Entity;
using PaparaProjectData.UnitOfWork;

namespace PaparaProjectBusiness.Features.Helpers.PurchaseHelper
{
    public class UpdateProductQuantity
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateProductQuantity(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<decimal> UpdateQuantity(int basketId)
        {
            decimal pointMultiplierPercentage = 0;
            List <BasketItem> basketItemList = await unitOfWork.BasketItemReadRepository.Where(bi => bi.BasketId == basketId);
            foreach (BasketItem basketItem in basketItemList)
            {
                Product product = await unitOfWork.ProductReadRepository.FirstOrDefault(p => p.Id == basketItem.ProductId);
                product.Stock = product.Stock - basketItem.Quantity;

                pointMultiplierPercentage += product.PointMultiplierPercentage;
                unitOfWork.ProductWriteRepository.Update(product);
            }
            return pointMultiplierPercentage / basketItemList.Count();
        }
    }
}
