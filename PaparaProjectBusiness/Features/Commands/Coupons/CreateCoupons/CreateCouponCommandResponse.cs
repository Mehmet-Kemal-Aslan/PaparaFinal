using PaparaProjectBase.APIResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Commands.Coupons.CreateCoupons
{
    public class CreateCouponCommandResponse<CouponResponse> : ApiResponse<CouponResponse>
    {
        public CouponResponse couponResponse { get; set; }
        public CreateCouponCommandResponse(CouponResponse response)
        {
            couponResponse = response;
        }
    }
}
