using MediatR;
using PaparaProjectBusiness.Features.Queries.Users.GetAllUsers;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Queries.Users.GetUserById
{
    public class GetUserByIdQueryRequest(string userId) : IRequest<GetUserByIdQueryResponse<UserResponse>>
    {
        public string UserId = userId;
    }
}
