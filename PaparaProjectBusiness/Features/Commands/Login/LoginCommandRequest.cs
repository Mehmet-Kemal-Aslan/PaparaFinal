using MediatR;
using PaparaProjectBase.APIResponse;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Commands.Login
{
    public class LoginCommandRequest : LoginRequest, IRequest<ApiResponse<LoginResponse>>
    {
        public LoginRequest loginRequest { get; }
        public LoginCommandRequest(LoginRequest request)
        {
            loginRequest = request;
        }
    }
}
