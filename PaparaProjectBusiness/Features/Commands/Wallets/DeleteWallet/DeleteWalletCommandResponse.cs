using Azure;
using PaparaProjectBase.APIResponse;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Commands.Wallets.DeleteWallet
{
    public class DeleteWalletCommandResponse : APIDeleteResponse
    {
        public WalletResponse walletResponse { get; set; }
        public DeleteWalletCommandResponse(WalletResponse response)
        {
            walletResponse = response;
        }
    }
}
