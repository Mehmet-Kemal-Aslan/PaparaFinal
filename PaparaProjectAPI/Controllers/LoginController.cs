using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaparaProjectBase.APIResponse;
using PaparaProjectBusiness.Features.Commands.Login;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;

namespace PaparaProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator mediator;

        public LoginController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost]
        [AllowAnonymous]
        //[ResponseHeader("MyCustomHeaderInResponse", "POST")]
        public async Task<ApiResponse<LoginResponse>> Post([FromBody] LoginRequest value)
        {
            LoginCommandRequest operation = new LoginCommandRequest(value);
            var result = await mediator.Send(operation);
            return result;

        }
    }
}
