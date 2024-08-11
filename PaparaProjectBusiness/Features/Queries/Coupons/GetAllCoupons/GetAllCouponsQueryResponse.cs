using PaparaProjectBase.APIResponse;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Queries.Coupons.GetAllCoupons
{
    public class GetAllCouponsQueryResponse<CouponResponseList> : ApiResponse<CouponResponse>
    {
        public List<CouponResponse> Coupons { get; set; }
        public GetAllCouponsQueryResponse(List<CouponResponse> couponList)
        {
            Coupons = couponList;
        }
    }
}
