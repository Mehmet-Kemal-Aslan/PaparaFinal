using MediatR;
using PaparaProjectBase.APIResponse;
using PaparaProjectBase.Models.Messages;
using PaparaProjectData.UnitOfWork;

namespace PaparaProjectBusiness.Features.Commands.Coupons.DeleteCoupons
{
    public class DeleteCouponCommandHandler : IRequestHandler<DeleteCouponCommandRequest, APIDeleteResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        public DeleteCouponCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<APIDeleteResponse> Handle(DeleteCouponCommandRequest request, CancellationToken cancellationToken)
        {
            bool disactivateResult = await unitOfWork.CouponWriteRepository.Disactivate(request.CouponId);
            await unitOfWork.Complete();
            APIDeleteResponse response = new APIDeleteResponse();
            if (disactivateResult is false)
                response.Message = ResponseMessages.NotFound;
            return response;
        }
    }
}
