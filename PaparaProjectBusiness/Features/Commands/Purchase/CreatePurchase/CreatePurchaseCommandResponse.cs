namespace PaparaProjectBusiness.Features.Commands.Purchase.Purchase
{
    public class CreatePurchaseCommandResponse<OrderResponse>
    {
        public OrderResponse orderResponse { get; set; }
        public CreatePurchaseCommandResponse(OrderResponse response)
        {
            orderResponse = response;
        }
    }
}
