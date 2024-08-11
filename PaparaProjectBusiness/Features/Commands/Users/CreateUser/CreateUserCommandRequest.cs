using MediatR;
using PaparaProjectBase.APIResponse;
using PaparaProjectBase.BaseRequests.UserRequests;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Commands.Users.CreateUser
{
    public class CreateUserCommandRequest : BaseUserRequest, IRequest<ApiResponse<UserResponse>>
    {
        public CreateUserCommandRequest(UserRequest request) : base(request)
        {
        }
    }
}
