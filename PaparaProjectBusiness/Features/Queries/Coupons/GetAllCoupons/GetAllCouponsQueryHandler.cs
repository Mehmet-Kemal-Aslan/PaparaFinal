using AutoMapper;
using MediatR;
using PaparaFinalData.Entity;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Queries.Coupons.GetAllCoupons
{
    public class GetAllCouponsQueryHandler : IRequestHandler<GetAllCouponsQueryRequest, GetAllCouponsQueryResponse<List<CouponResponse>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllCouponsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<GetAllCouponsQueryResponse<List<CouponResponse>>> Handle(GetAllCouponsQueryRequest request, CancellationToken cancellationToken)
        {
            List<Coupon> couponList = await unitOfWork.CouponReadRepository.GetAll();
            List<CouponResponse> mappedList = mapper.Map<List<CouponResponse>>(couponList);
            return new GetAllCouponsQueryResponse<List<CouponResponse>>(mappedList);
        }
    }
}
