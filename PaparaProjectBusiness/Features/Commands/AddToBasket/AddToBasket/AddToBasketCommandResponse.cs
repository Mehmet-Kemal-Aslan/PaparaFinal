namespace PaparaProjectBusiness.Features.Commands.AddToBasket.AddToBasket
{
    public class AddToBasketCommandResponse<BasketResponse>
    {
        public BasketResponse basketResponse { get; set; }
        public AddToBasketCommandResponse(BasketResponse response)
        {
            basketResponse = response;
        }
    }
}
