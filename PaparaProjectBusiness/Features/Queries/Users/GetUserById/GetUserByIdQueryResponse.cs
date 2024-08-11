using PaparaProjectBase.APIResponse;

namespace PaparaProjectBusiness.Features.Queries.Users.GetUserById
{
    public class GetUserByIdQueryResponse<UserResponse> : ApiResponse<UserResponse>
    {
        public UserResponse User { get; set; }
        public GetUserByIdQueryResponse(UserResponse user)
        {
            User = user;
        }
    }
}
