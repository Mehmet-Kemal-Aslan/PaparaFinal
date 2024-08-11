using MediatR;
using PaparaProjectBase.APIResponse;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Commands.Wallets.UpdateWallet
{
    public class UpdateWalletCommandRequest : WalletRequest, IRequest<ApiResponse<WalletResponse>>
    {
        public WalletRequest walletRequest { get; }
        public int walletId { get; }
        public UpdateWalletCommandRequest(int Id, WalletRequest request)
        {
            walletRequest = request;
            walletId = Id;
        }
    }
}
