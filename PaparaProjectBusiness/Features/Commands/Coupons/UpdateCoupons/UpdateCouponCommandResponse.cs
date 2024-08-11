using PaparaProjectBase.APIResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Commands.Coupons.UpdateCoupons
{
    public class UpdateCouponCommandResponse<CouponResponse> : ApiResponse<CouponResponse>
    {
        public CouponResponse couponResponse { get; set; }
        public UpdateCouponCommandResponse(CouponResponse response)
        {
            couponResponse = response;
        }
    }
}
