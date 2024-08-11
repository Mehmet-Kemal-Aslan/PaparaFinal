using AutoMapper;
using MediatR;
using PaparaFinalData.Entity;
using PaparaProjectBase.APIResponse;
using PaparaProjectBusiness.Validation.Validators;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Commands.Coupons.CreateCoupons
{
    public class CreateCouponCommandHandler : IRequestHandler<CreateCouponCommandRequest, ApiResponse<CouponResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateCouponCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<CouponResponse>> Handle(CreateCouponCommandRequest request, CancellationToken cancellationToken)
        {
            CouponValidator couponValidator = new CouponValidator(unitOfWork);
            var validationResult = await couponValidator.ValidateAsync(request.couponRequest);
            ApiResponse<CouponResponse> validationResponse = new ApiResponse<CouponResponse>(null);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                validationResponse.Message = errors;
                validationResponse.IsSuccess = false;
                validationResponse.Health = true;
                return validationResponse;
            }

            var mapped = mapper.Map<CouponRequest, Coupon>(request.couponRequest);
            await unitOfWork.CouponWriteRepository.Insert(mapped);
            await unitOfWork.Complete();

            var response = mapper.Map<CouponResponse>(mapped);
            return new ApiResponse<CouponResponse>(response);
        }
    }
}
