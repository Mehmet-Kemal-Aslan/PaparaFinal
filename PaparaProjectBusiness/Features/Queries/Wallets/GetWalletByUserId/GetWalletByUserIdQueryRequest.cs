using MediatR;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Queries.Wallets.GetWalletById
{
    public class GetWalletByUserIdQueryRequest(int userId) : IRequest<GetWalletByUserIdQueryResponse<WalletResponse>>
    {
        public int UserId = userId;
    }
}
