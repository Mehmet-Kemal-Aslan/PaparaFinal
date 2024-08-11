using Azure;
using PaparaProjectBase.APIResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Commands.Wallets.UpdateWallet
{
    public class UpdateWalletCommandResponse<WalletResponse> : ApiResponse<WalletResponse>
    {
        public WalletResponse walletResponse { get; set; }
        public UpdateWalletCommandResponse(WalletResponse response)
        {
            walletResponse = response;
        }
    }
}
