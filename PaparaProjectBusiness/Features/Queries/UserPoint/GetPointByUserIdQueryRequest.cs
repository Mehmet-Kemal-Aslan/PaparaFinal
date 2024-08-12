using MediatR;
using PaparaProjectBusiness.Features.Queries.Wallets.GetWalletById;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Queries.UserPoint
{
    public class GetPointByUserIdQueryRequest(int userId) : IRequest<GetPointByUserIdQueryResponse<PointResponse>>
    {
        public int UserId = userId;
    }
}
