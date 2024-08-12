using MediatR;
using PaparaProjectBase.APIResponse;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Commands.AddToBasket.AddToBasket
{
    public class AddToBasketCommandRequest : AddToBasketRequest, IRequest<ApiResponse<BasketResponse>>
    {
        public AddToBasketRequest addToBasketRequest { get; }
        public AddToBasketCommandRequest(AddToBasketRequest request)
        {
            addToBasketRequest = request;
        }
    }
}
