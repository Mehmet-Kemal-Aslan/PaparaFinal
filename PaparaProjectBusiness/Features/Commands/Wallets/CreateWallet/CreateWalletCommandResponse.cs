using PaparaProjectBase.APIResponse;

namespace PaparaProjectBusiness.Features.Commands.Wallets.CreateWallet
{
    public class CreateWalletCommandResponse<WalletResponse> : ApiResponse<WalletResponse>
    {
        public WalletResponse walletResponse { get; set; }
        public CreateWalletCommandResponse(WalletResponse response)
        {
            walletResponse = response;
        }
    }
}
