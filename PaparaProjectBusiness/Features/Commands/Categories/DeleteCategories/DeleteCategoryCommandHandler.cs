using MediatR;
using PaparaFinalData.Entity;
using PaparaProjectBase.APIResponse;
using PaparaProjectBase.Models.Messages;
using PaparaProjectData.UnitOfWork;

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
            Product products = await unitOfWork.ProductReadRepository.FirstOrDefault(c => c.ProductCategoryMaps.Any(pcm => pcm.CategoryId == request.CategoryId));
            if (products is not null) 
            {
                APIDeleteResponse notNullAttention = new APIDeleteResponse();
                notNullAttention.Message = ResponseMessages.CategoryHasProducts;
                return notNullAttention;
            }
            bool deleteResult = await unitOfWork.CategoryWriteRepository.Delete(request.CategoryId);
            await unitOfWork.Complete();
            APIDeleteResponse response = new APIDeleteResponse();
            if (deleteResult is false)
                response.Message = ResponseMessages.NotFound;
            return response;
        }
    }
}
