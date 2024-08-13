using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaparaProjectBase.APIResponse;
using PaparaProjectBusiness.Features.Commands.AddToBasket.AddToBasket;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;

namespace PaparaProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddToBasketController : ControllerBase
    {
        private readonly IMediator mediator;

        public AddToBasketController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Normal")]
        public async Task<ApiResponse<BasketResponse>> Post([FromBody] AddToBasketRequest value)
        {
            AddToBasketCommandRequest operation = new AddToBasketCommandRequest(value);
            ApiResponse<BasketResponse> result = await mediator.Send(operation);
            return result;
        }
    }
}
