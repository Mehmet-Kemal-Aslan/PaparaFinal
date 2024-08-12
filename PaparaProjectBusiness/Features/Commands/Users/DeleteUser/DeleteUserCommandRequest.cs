using MediatR;
using PaparaProjectBase.APIResponse;
using PaparaProjectBusiness.Features.Commands.Users.CreateUser;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Commands.Users.DeleteUser
{
    public class DeleteUserCommandRequest(int userId) : IRequest<APIDeleteResponse>
    {
        public int UserId = userId;
    }
}
