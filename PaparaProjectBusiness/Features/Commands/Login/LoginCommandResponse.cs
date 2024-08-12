using PaparaProjectBase.APIResponse;

namespace PaparaProjectBusiness.Features.Commands.Login
{
    public class LoginCommandResponse<LoginResponse> : ApiResponse<LoginResponse>
    {
        public LoginResponse loginResponse { get; set; }
        public LoginCommandResponse(LoginResponse response)
        {
            loginResponse = response;
        }
    }
}
