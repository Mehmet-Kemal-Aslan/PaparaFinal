using PaparaProjectBase.APIResponse;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Queries.Users.GetAllUsers
{
    public class GetAllUsersQueryResponse<UserResponseList> : ApiResponse<UserResponse>
    {
        public List<UserResponse> Users { get; set; }
        public GetAllUsersQueryResponse(List<UserResponse> userList)
        {
            Users = userList;
        }
    }
}
