using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaparaProjectBase.APIResponse;
using PaparaProjectBusiness.Features.Commands.Users.CreateUser;
using PaparaProjectBusiness.Features.Commands.Users.DeleteUser;
using PaparaProjectBusiness.Features.Commands.Users.UpdateUser;
using PaparaProjectBusiness.Features.Queries.Users.GetAllUsers;
using PaparaProjectBusiness.Features.Queries.Users.GetUserById;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;

namespace PaparaProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersContoller : ControllerBase
    {
        private readonly IMediator mediator;

        public UsersContoller(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        //[Authorize(Roles = "admin")]
        public async Task<GetAllUsersQueryResponse<List<UserResponse>>> GetAll()
        {
            var operation = new GetAllUsersQueryRequest();
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpGet("{UserId}")]
        //[Authorize(Roles = "admin")]
        public async Task<GetUserByIdQueryResponse<UserResponse>> Get([FromRoute] string UserId)
        {
            var operation = new GetUserByIdQueryRequest(UserId);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPost]
        //[Authorize(Roles = "admin")]
        public async Task<ApiResponse<UserResponse>> Post([FromBody] UserRequest value)
        {
            CreateUserCommandRequest operation = new CreateUserCommandRequest(value);
            ApiResponse<UserResponse> result = await mediator.Send(operation);
            return result;
        }

        [HttpPut]
        //[Authorize(Roles = "admin")]
        public async Task<ApiResponse<UserResponse>> Put([FromBody] UserRequest value)
        {
            var operation = new UpdateUserCommandRequest(value);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpDelete("{userId}")]
        //[authorize(roles = "admin")]
        public async Task<APIDeleteResponse> Delete(string userId)
        {
            var operation = new DeleteUserCommandRequest(userId);
            var result = await mediator.Send(operation);
            return result;
        }
    }
}
