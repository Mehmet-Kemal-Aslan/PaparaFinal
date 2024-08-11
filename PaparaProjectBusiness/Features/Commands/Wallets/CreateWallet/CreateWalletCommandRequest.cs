using MediatR;
using PaparaProjectBase.APIResponse;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Commands.Wallets.CreateWallet
{
    public class CreateWalletCommandRequest : WalletRequest, IRequest<ApiResponse<WalletResponse>>
    {
        public WalletRequest walletRequest { get; }
        public CreateWalletCommandRequest(WalletRequest request)
        {
            walletRequest = request;
        }
    }
}
