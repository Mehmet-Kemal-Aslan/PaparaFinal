using MediatR;
using PaparaProjectBase.APIResponse;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Commands.Coupons.UpdateCoupons
{
    public class UpdateCouponCommandRequest : CouponRequest, IRequest<ApiResponse<CouponResponse>>
    {
        public CouponRequest couponRequest { get; }
        public int couponId { get; }
        public UpdateCouponCommandRequest(int Id, CouponRequest request)
        {
            couponRequest = request;
            couponId = Id;
        }
    }
}
