using MediatR;
using PaparaProjectBase.APIResponse;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Commands.Coupons.DeleteCoupons
{
    public class DeleteCouponCommandResponse : APIDeleteResponse
    {
        public CouponResponse couponResponse { get; set; }
        public DeleteCouponCommandResponse(CouponResponse response)
        {
            couponResponse = response;
        }
    }
}
