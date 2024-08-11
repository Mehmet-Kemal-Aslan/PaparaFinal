using MediatR;
using PaparaProjectBase.APIResponse;
using PaparaProjectBusiness.Features.Commands.Categories.DeleteCategories;
using PaparaProjectData.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Commands.Products.DeleteProducts
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, APIDeleteResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<APIDeleteResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            bool deleteResult = await unitOfWork.ProductWriteRepository.Delete(request.ProductId);
            await unitOfWork.Complete();
            APIDeleteResponse response = new APIDeleteResponse();
            if (deleteResult is false)
                response.Message = "bulunamadı";
            return response;
        }
    }
}
