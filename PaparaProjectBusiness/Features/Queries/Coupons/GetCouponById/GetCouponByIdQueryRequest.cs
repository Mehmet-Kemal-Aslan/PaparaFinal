using MediatR;
using PaparaProjectBusiness.Features.Queries.Categories.GetCategoryById;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Queries.Coupons.GetCouponById
{
    public class GetCouponByIdQueryRequest(int couponId) : IRequest<GetCouponByIdQueryResponse<CouponResponse>>
    {
        public int CouponId = couponId;
    }
}
