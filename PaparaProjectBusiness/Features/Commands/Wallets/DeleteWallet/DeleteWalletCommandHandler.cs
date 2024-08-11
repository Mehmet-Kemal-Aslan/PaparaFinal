using MediatR;
using PaparaProjectBase.APIResponse;
using PaparaProjectBusiness.Features.Commands.Users.DeleteUser;
using PaparaProjectData.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Commands.Wallets.DeleteWallet
{
    public class DeleteWalletCommandHandler : IRequestHandler<DeleteWalletCommandRequest, APIDeleteResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        public DeleteWalletCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<APIDeleteResponse> Handle(DeleteWalletCommandRequest request, CancellationToken cancellationToken)
        {
            bool deleteResult = await unitOfWork.WalletWriteRepository.Delete(request.UserId);
            await unitOfWork.Complete();
            APIDeleteResponse response = new APIDeleteResponse();
            if (deleteResult is false)
                response.Message = "bulunamadı";
            return new APIDeleteResponse();
        }
    }
}
