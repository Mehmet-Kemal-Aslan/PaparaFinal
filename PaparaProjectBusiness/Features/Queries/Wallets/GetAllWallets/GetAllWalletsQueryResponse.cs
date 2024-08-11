using PaparaProjectBase.APIResponse;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Queries.Wallets.GetAllWallets
{
    public class GetAllWalletsQueryResponse<WalletResponseList> : ApiResponse<WalletResponse>
    {
        public List<WalletResponse> Wallets { get; set; }
        public GetAllWalletsQueryResponse(List<WalletResponse> walletList)
        {
            Wallets = walletList;
        }
    }
}
