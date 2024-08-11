using MediatR;
using PaparaProjectBase.APIResponse;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Commands.Coupons.CreateCoupons
{
    public class CreateCouponCommandRequest : IRequest<ApiResponse<CouponResponse>>
    {
        public CouponRequest couponRequest { get; }
        public CreateCouponCommandRequest(CouponRequest request)
        {
            couponRequest = request;
        }
    }
}
