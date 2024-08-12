using AutoMapper;
using MediatR;
using PaparaFinalData.Entity;
using PaparaProjectBase.Models.Messages;
using PaparaProjectBusiness.Features.Queries.Wallets.GetWalletById;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Queries.UserPoint
{
    public class GetPointByUserIdQueryHandler : IRequestHandler<GetPointByUserIdQueryRequest, GetPointByUserIdQueryResponse<PointResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetPointByUserIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<GetPointByUserIdQueryResponse<PointResponse>> Handle(GetPointByUserIdQueryRequest request, CancellationToken cancellationToken)
        {
            User user = await unitOfWork.UserReadRepository.FirstOrDefault(u => u.Id == request.UserId);
            GetPointByUserIdQueryResponse<PointResponse> nullResponse = new GetPointByUserIdQueryResponse<PointResponse>(null);
            if (user == null)
            {
                nullResponse.Message = ResponseMessages.NotFound;
                return nullResponse;
            }
            PointResponse response = new PointResponse()
            {
                Name = user.Name,
                Surname = user.Surname,
                Point = user.Point ?? 0
            };
            return new GetPointByUserIdQueryResponse<PointResponse>(response);
        }
    }
}
