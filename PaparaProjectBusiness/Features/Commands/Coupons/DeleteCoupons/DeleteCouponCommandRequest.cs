using MediatR;
using PaparaProjectBase.APIResponse;

namespace PaparaProjectBusiness.Features.Commands.Coupons.DeleteCoupons
{
    public class DeleteCouponCommandRequest(int couponId) : IRequest<APIDeleteResponse>
    {
        public int CouponId = couponId;
    }
}
