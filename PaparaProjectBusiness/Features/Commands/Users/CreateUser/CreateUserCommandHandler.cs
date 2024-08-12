using AutoMapper;
using MediatR;
using PaparaFinalData.Entity;
using PaparaProjectBase.APIResponse;
using PaparaProjectBase.Models.Notification;
using PaparaProjectBase.Models.UserRoles;
using PaparaProjectBusiness.Validation.ValidationChecks.User;
using PaparaProjectBussiness.RabbitMQ;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;
using System.Text.Json;

namespace PaparaProjectBusiness.Features.Commands.Users.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, ApiResponse<UserResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IEmailQueuePublisher emailQueuePublisher;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailQueuePublisher emailQueuePublisher)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.emailQueuePublisher = emailQueuePublisher;
        }

        public async Task<ApiResponse<UserResponse>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            UserValidationCheck userValidator = new UserValidationCheck();
            var validationResult = await userValidator.CheckUserValidation(request);
            if (validationResult.IsSuccess is false)
                return validationResult;

            var mapped = mapper.Map<UserRequest, User>(request.Request);
            mapped.Role = UserRoles.Normal;
            await unitOfWork.UserWriteRepository.Insert(mapped);
            await unitOfWork.Complete();

            var emailMessage = new EmailMessage
            {
                Subject = NewUserMail.Subject,
                Email = request.Request.Email,
                Content = NewUserMail.Content,
            };
            var emailMessageJson = JsonSerializer.Serialize(emailMessage);
            emailQueuePublisher.Publish(emailMessageJson);

            var response = mapper.Map<UserResponse>(mapped);
            return new ApiResponse<UserResponse>(response);
        }
    }
}
