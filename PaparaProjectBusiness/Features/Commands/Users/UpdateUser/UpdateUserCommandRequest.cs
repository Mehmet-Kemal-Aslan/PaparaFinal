using MediatR;
using PaparaProjectBase.APIResponse;
using PaparaProjectBase.BaseRequests.UserRequests;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Commands.Users.UpdateUser
{
    public class UpdateUserCommandRequest : BaseUserRequest, IRequest<ApiResponse<UserResponse>>
    {
        public int userId { get; }
        public UpdateUserCommandRequest(int Id, UserRequest request) : base(request)
        {
            userId = Id;
        }
    }
}
