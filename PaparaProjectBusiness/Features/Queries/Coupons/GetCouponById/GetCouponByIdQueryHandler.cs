using AutoMapper;
using MediatR;
using PaparaFinalData.Entity;
using PaparaProjectBase.Models.Messages;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Queries.Coupons.GetCouponById
{
    public class GetCouponByIdQueryHandler : IRequestHandler<GetCouponByIdQueryRequest, GetCouponByIdQueryResponse<CouponResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetCouponByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<GetCouponByIdQueryResponse<CouponResponse>> Handle(GetCouponByIdQueryRequest request, CancellationToken cancellationToken)
        {
            Coupon coupon = await unitOfWork.CouponReadRepository.GetById(request.CouponId);
            if (coupon == null)
            {
                GetCouponByIdQueryResponse<CouponResponse> nullResponse = new GetCouponByIdQueryResponse<CouponResponse>(null);
                nullResponse.Message = ResponseMessages.NotFound;
                return nullResponse;
            }
            CouponResponse mappedCategories = mapper.Map<CouponResponse>(coupon);
            return new GetCouponByIdQueryResponse<CouponResponse>(mappedCategories);
        }
    }
}
