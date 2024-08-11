using Azure;
using PaparaProjectBase.APIResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Commands.Users.UpdateUser
{
    public class UpdateUserCommandResponse<UserResponse> : ApiResponse<UserResponse>
    {
        public UserResponse userResponse { get; set; }
        public UpdateUserCommandResponse(UserResponse response)
        {
            userResponse = response;
        }
    }
}
