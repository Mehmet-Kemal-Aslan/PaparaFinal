using PaparaProjectBase.APIResponse;
using PaparaProjectBase.BaseRequests.UserRequests;
using PaparaProjectBusiness.Validation.Validators;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Validation.ValidationChecks.User
{
    public class UserValidationCheck
    {
        public async Task<ApiResponse<UserResponse>> CheckUserValidation(BaseUserRequest request)
        {
            UsersValidator usersVallidator = new UsersValidator();
            var validationResult = await usersVallidator.ValidateAsync(request.Request);
            ApiResponse<UserResponse> validationResponse = new ApiResponse<UserResponse>(null);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                validationResponse.Message = errors;
                validationResponse.IsSuccess = false;
                validationResponse.Health = true;
                return validationResponse;
            }
            return validationResponse;
        }
    }
}
