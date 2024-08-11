using MediatR;
using PaparaProjectBase.APIResponse;

namespace PaparaProjectBusiness.Features.Commands.Wallets.DeleteWallet
{
    public class DeleteWalletCommandRequest(int userId) : IRequest<APIDeleteResponse>
    {
        public int UserId = userId;
    }
}
