using AutoMapper;
using MediatR;
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

            var mapped = mapper.Map<UserRequest, User>(request.Request);
            mapped.Id = request.userId;
            unitOfWork.UserWriteRepository.Update(mapped);
            await unitOfWork.Complete();

            var response = mapper.Map<UserResponse>(mapped);
            return new UpdateUserCommandResponse<UserResponse>(response);
        }
    }
}
