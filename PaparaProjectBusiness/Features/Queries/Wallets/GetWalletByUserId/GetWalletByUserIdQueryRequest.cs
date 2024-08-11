using MediatR;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Queries.Wallets.GetWalletById
{
    public class GetWalletByUserIdQueryRequest(string userId) : IRequest<GetWalletByUserIdQueryResponse<WalletResponse>>
    {
        public string UserId = userId;
    }
}
