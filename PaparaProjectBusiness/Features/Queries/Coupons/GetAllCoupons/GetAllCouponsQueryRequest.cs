using MediatR;
using PaparaProjectBusiness.Features.Queries.Categories.GetAllCategories;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Queries.Coupons.GetAllCoupons
{
    public class GetAllCouponsQueryRequest : IRequest<GetAllCouponsQueryResponse<List<CouponResponse>>>
    {
    }
}
