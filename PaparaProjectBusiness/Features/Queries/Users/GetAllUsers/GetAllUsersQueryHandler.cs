using AutoMapper;
using MediatR;
using PaparaFinalData.Entity;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Queries.Users.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQueryRequest, GetAllUsersQueryResponse<List<UserResponse>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<GetAllUsersQueryResponse<List<UserResponse>>> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
        {
            List<User> userList = await unitOfWork.UserReadRepository.GetAll();
            var mappedList = mapper.Map<List<UserResponse>>(userList);
            return new GetAllUsersQueryResponse<List<UserResponse>>(mappedList);
        }
    }
}
