using PaparaProjectBase.APIResponse;

namespace PaparaProjectBusiness.Features.Queries.Wallets.GetWalletById
{
    public class GetWalletByUserIdQueryResponse<WalletResponse> : ApiResponse<WalletResponse>
    {
        public List<WalletResponse> Wallets { get; set; }
        public GetWalletByUserIdQueryResponse(List<WalletResponse> walletList)
        {
            Wallets = walletList;
        }
    }
}
