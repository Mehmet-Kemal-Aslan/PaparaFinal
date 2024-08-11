using PaparaProjectBase.APIResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Queries.Coupons.GetCouponById
{
    public class GetCouponByIdQueryResponse<CouponResponse> : ApiResponse<CouponResponse>
    {
        public CouponResponse Coupon { get; set; }
        public GetCouponByIdQueryResponse(CouponResponse coupon)
        {
            Coupon = coupon;
        }
    }
}
