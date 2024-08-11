using AutoMapper;
using MediatR;
using PaparaFinalData.Entity;
using PaparaProjectBusiness.Features.Queries.Users.GetAllUsers;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Queries.Users.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQueryRequest, GetUserByIdQueryResponse<UserResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<GetUserByIdQueryResponse<UserResponse>> Handle(GetUserByIdQueryRequest request, CancellationToken cancellationToken)
        {
            User user = await unitOfWork.UserReadRepository.GetById(request.UserId);
            var mappedUser = mapper.Map<UserResponse>(user);
            return new GetUserByIdQueryResponse<UserResponse>(mappedUser);
        }
    }
}
