using AutoMapper;
using MediatR;
using PaparaFinalData.Entity;
using PaparaProjectBase.APIResponse;
using PaparaProjectBusiness.Features.Commands.Categories.UpdateCategories;
using PaparaProjectBusiness.Validation.Validators;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Commands.Coupons.UpdateCoupons
{
    public class UpdateCouponCommandHandler : IRequestHandler<UpdateCouponCommandRequest, ApiResponse<CouponResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateCouponCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<CouponResponse>> Handle(UpdateCouponCommandRequest request, CancellationToken cancellationToken)
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
            mapped.Id = request.couponId;
            unitOfWork.CouponWriteRepository.Update(mapped);
            await unitOfWork.Complete();

            var response = mapper.Map<CouponResponse>(mapped);
            return new ApiResponse<CouponResponse>(response);
        }
    }
}
