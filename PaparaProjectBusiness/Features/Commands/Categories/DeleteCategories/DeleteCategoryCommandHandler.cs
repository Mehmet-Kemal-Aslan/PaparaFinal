using MediatR;
using PaparaProjectBase.APIResponse;
using PaparaProjectBusiness.Features.Commands.Wallets.DeleteWallet;
using PaparaProjectData.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Commands.Categories.DeleteCategories
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, APIDeleteResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<APIDeleteResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            bool deleteResult = await unitOfWork.CategoryWriteRepository.Delete(request.CategoryId);
            await unitOfWork.Complete();
            APIDeleteResponse response = new APIDeleteResponse();
            if(deleteResult is false)
                response.Message = "bulunamadı";
            return response;
        }
    }
}
