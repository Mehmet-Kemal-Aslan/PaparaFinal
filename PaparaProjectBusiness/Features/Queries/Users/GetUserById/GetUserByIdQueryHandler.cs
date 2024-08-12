using AutoMapper;
using MediatR;
using PaparaFinalData.Entity;
using PaparaProjectBase.Models.Messages;
using PaparaProjectBusiness.Features.Queries.Coupons.GetCouponById;
using PaparaProjectBusiness.Features.Queries.Users.GetAllUsers;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

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
            if (user == null)
            {
                GetUserByIdQueryResponse<UserResponse> nullResponse = new GetUserByIdQueryResponse<UserResponse>(null);
                nullResponse.Message = ResponseMessages.NotFound;
                return nullResponse;
            }
            var mappedUser = mapper.Map<UserResponse>(user);
            return new GetUserByIdQueryResponse<UserResponse>(mappedUser);
        }
    }
}
