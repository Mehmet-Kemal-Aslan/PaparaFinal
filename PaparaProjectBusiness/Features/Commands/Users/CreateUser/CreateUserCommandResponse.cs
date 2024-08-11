using PaparaProjectBase.APIResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Commands.Users.CreateUser
{
    public class CreateUserCommandResponse<UserResponse> : ApiResponse<UserResponse>
    {
        public UserResponse userResponse { get; set; }
        public CreateUserCommandResponse(UserResponse response)
        {
            userResponse = response;
        }
    }
}
