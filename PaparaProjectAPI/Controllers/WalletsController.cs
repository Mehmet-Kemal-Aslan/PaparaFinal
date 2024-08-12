using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaparaProjectBase.APIResponse;
using PaparaProjectBusiness.Features.Commands.Wallets.CreateWallet;
using PaparaProjectBusiness.Features.Commands.Wallets.DeleteWallet;
using PaparaProjectBusiness.Features.Commands.Wallets.UpdateWallet;
using PaparaProjectBusiness.Features.Queries.Wallets.GetAllWallets;
using PaparaProjectBusiness.Features.Queries.Wallets.GetWalletById;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;

namespace PaparaProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletsController : ControllerBase
    {
        private readonly IMediator mediator;

        public WalletsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        //[Authorize(Roles = "admin")]
        public async Task<GetAllWalletsQueryResponse<List<WalletResponse>>> GetAll()
        {
            GetAllWalletsQueryRequest operation = new GetAllWalletsQueryRequest();
            GetAllWalletsQueryResponse<List<WalletResponse>> result = await mediator.Send(operation);
            return result;
        }

        [HttpGet("{UserId}")]
        //[Authorize(Roles = "admin")]
        public async Task<GetWalletByUserIdQueryResponse<WalletResponse>> Get([FromRoute] int UserId)
        {
            GetWalletByUserIdQueryRequest operation = new GetWalletByUserIdQueryRequest(UserId);
            GetWalletByUserIdQueryResponse<WalletResponse> result = await mediator.Send(operation);
            return result;
        }

        [HttpPost]
        //[Authorize(Roles = "admin")]
        public async Task<ApiResponse<WalletResponse>> Post([FromBody] WalletRequest value)
        {
            CreateWalletCommandRequest operation = new CreateWalletCommandRequest(value);
            ApiResponse<WalletResponse> result = await mediator.Send(operation);
            return result;
        }

        [HttpPut("{walletId}")]
        //[Authorize(Roles = "admin")]
        public async Task<ApiResponse<WalletResponse>> Put(int walletId, [FromBody] WalletRequest value)
        {
            UpdateWalletCommandRequest operation = new UpdateWalletCommandRequest(walletId, value);
            ApiResponse<WalletResponse> result = await mediator.Send(operation);
            return result;
        }

        [HttpDelete("{walletId}")]
        //[authorize(roles = "admin")]
        public async Task<APIDeleteResponse> Delete(int walletId)
        {
            DeleteWalletCommandRequest operation = new DeleteWalletCommandRequest(walletId);
            APIDeleteResponse result = await mediator.Send(operation);
            return result;
        }
    }
}
