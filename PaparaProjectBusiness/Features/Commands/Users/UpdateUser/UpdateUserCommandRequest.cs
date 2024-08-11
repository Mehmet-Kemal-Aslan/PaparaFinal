using MediatR;
using PaparaProjectBase.APIResponse;
using PaparaProjectBase.BaseRequests.UserRequests;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Commands.Users.UpdateUser
{
    public class UpdateUserCommandRequest : BaseUserRequest, IRequest<ApiResponse<UserResponse>>
    {
        public UpdateUserCommandRequest(UserRequest request) : base(request)
        {
        }
    }
}
