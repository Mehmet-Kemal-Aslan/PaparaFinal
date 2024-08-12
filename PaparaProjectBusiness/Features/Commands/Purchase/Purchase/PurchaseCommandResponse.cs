namespace PaparaProjectBusiness.Features.Commands.Purchase.Purchase
{
    public class PurchaseCommandResponse<PurchaseResponse>
    {
        public PurchaseResponse purchaseResponse { get; set; }
        public PurchaseCommandResponse(PurchaseResponse response)
        {
            purchaseResponse = response;
        }
    }
}
