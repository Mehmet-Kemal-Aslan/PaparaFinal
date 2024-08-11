using AutoMapper;
using MediatR;
using PaparaProjectBase.APIResponse;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            await unitOfWork.UserWriteRepository.Delete(request.UserId);
            await unitOfWork.Complete();
            APIDeleteResponse response = new APIDeleteResponse();
            return new APIDeleteResponse();
        }
    }
}
