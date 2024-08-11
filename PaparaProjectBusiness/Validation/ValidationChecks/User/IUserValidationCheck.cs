using Azure;
using FluentValidation;
using PaparaProjectBase.APIResponse;
using PaparaProjectBase.BaseRequests.UserRequests;

namespace PaparaProjectBusiness.Validation.ValidationChecks.User
{
    public interface IUserValidationCheck<TRequest, TResponse, TValidator> 
        where TRequest : class
        where TValidator : AbstractValidator<TRequest>
    {
        Task<ApiResponse<TResponse>> CheckUserValidation(TRequest request, TValidator validator);
    }
}
