using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaparaProjectBase.APIResponse;
using PaparaProjectBusiness.Features.Commands.Purchase.Purchase;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;

namespace PaparaProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IMediator mediator;

        public PurchaseController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Normal")]
        public async Task<ApiResponse<OrderResponse>> Post([FromBody] PurchaseRequest value)
        {
            CreatePurchaseCommandRequest operation = new CreatePurchaseCommandRequest(value);
            ApiResponse<OrderResponse> result = await mediator.Send(operation);
            return result;
        }
    }
}
