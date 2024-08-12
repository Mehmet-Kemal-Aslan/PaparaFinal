using PaparaProjectBase.APIResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Queries.UserPoint
{
    public class GetPointByUserIdQueryResponse<PointResponse> : ApiResponse<PointResponse>
    {
        public PointResponse Point { get; set; }
        public GetPointByUserIdQueryResponse(PointResponse point)
        {
            Point = point;
        }
    }
}
