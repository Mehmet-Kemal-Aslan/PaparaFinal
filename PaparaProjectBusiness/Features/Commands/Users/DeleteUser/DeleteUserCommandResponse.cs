using Azure;
using PaparaProjectBase.APIResponse;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Commands.Users.DeleteUser
{
    public class DeleteUserCommandResponse : ApiResponse
    {
        public APIDeleteResponse userResponse { get; set; }
        public DeleteUserCommandResponse()
        {
            APIDeleteResponse response = new APIDeleteResponse();
            response.Message = userResponse.Message;
        }
    }
}
