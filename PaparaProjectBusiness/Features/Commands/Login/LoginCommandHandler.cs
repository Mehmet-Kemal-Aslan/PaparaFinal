using AutoMapper;
using MediatR;
using PaparaFinalData.Entity;
using PaparaProjectBase.APIResponse;
using PaparaProjectBase.Models.Messages;
using PaparaProjectBusiness.Token;
using PaparaProjectBusiness.Validation.Validators;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, ApiResponse<LoginResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private ITokenService tokenService;

        public LoginCommandHandler(IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            this.unitOfWork = unitOfWork;
            this.tokenService = tokenService;
        }

        public async Task<ApiResponse<LoginResponse>> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            LoginValidator usersValidator = new LoginValidator();
            var validationResult = await usersValidator.ValidateAsync(request.loginRequest);
            ApiResponse<LoginResponse> validationResponse = new ApiResponse<LoginResponse>(null);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                validationResponse.Message = errors;
                validationResponse.IsSuccess = false;
                validationResponse.Health = true;
                return validationResponse;
            }

            User? user = await unitOfWork.UserReadRepository.FirstOrDefault(u => u.UserName == request.loginRequest.UserName);
            ApiResponse<LoginResponse> response = new ApiResponse<LoginResponse>(new LoginResponse { });
            if (user is null)
            {
                response.Message = ResponseMessages.InvalidUserInformation;
                return response;
            }
            if (user.Password != request.loginRequest.Password)
            {
                response.Message = ResponseMessages.InvalidUserInformation;
                return response;
            }

            var token = await tokenService.GetToken(user);
            response.Data.ExpireTime = DateTime.Now.AddDays(1);
            response.Data.AccessToken = token;
            response.Data.UserName = user.UserName;
            return response;
        }
    }
}
