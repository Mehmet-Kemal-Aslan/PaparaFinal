using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using PaparaFinalData.Entity;
using PaparaProjectBase.APIResponse;
using PaparaProjectBusiness.Features.Commands.Users.CreateUser;
using PaparaProjectBusiness.Validation.ValidationChecks.User;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Commands.Users.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, ApiResponse<UserResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<ApiResponse<UserResponse>> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            UserValidationCheck userValidator = new UserValidationCheck();
            var validationResult = await userValidator.CheckUserValidation(request);
            if (validationResult.IsSuccess is false)
                return validationResult;

            var passwordHasher = new PasswordHasher<IdentityUser>();
            var mapped = mapper.Map<UserRequest, User>(request.Request);
            string hashedPassword = passwordHasher.HashPassword(mapped, request.Request.Password);
            mapped.PasswordHash = hashedPassword;
            unitOfWork.UserWriteRepository.Update(mapped);
            await unitOfWork.Complete();

            var response = mapper.Map<UserResponse>(mapped);
            return new UpdateUserCommandResponse<UserResponse>(response);
        }
    }
}
