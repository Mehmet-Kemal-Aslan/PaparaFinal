using MediatR;
using PaparaProjectBase.APIResponse;
using PaparaProjectBase.Models.Messages;
using PaparaProjectData.UnitOfWork;

namespace PaparaProjectBusiness.Features.Commands.Users.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, APIDeleteResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<APIDeleteResponse> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            bool deleteResult = await unitOfWork.UserWriteRepository.Delete(request.UserId);
            await unitOfWork.Complete();
            APIDeleteResponse response = new APIDeleteResponse();
            if (deleteResult is false)
                response.Message = ResponseMessages.NotFound;
            return new APIDeleteResponse();
        }
    }
}
