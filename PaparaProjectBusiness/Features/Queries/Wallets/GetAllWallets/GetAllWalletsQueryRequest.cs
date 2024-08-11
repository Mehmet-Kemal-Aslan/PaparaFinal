using MediatR;
using PaparaProjectBusiness.Features.Queries.Users.GetAllUsers;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Queries.Wallets.GetAllWallets
{
    public class GetAllWalletsQueryRequest : IRequest<GetAllWalletsQueryResponse<List<WalletResponse>>>
    {
    }
}
