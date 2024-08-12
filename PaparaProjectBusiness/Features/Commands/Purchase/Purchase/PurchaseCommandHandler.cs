using AutoMapper;
using MediatR;
using PaparaFinalData.Entity;
using PaparaProjectBase.APIResponse;
using PaparaProjectBusiness.Features.Helpers.PurchaseHelper;
using PaparaProjectBusiness.Features.Helpers.PurchaseHelper.Model;
using PaparaProjectBusiness.Validation.Validators;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Commands.Purchase.Purchase
{
    public class PurchaseCommandHandler : IRequestHandler<PurchaseCommandRequest, ApiResponse<PurchaseResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PurchaseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<PurchaseResponse>> Handle(PurchaseCommandRequest request, CancellationToken cancellationToken)
        {
            PurchaseValidator purchaseValidator = new PurchaseValidator();
            var validationResult = await purchaseValidator.ValidateAsync(request.purchaseRequest);
            ApiResponse<PurchaseResponse> validationResponse = new ApiResponse<PurchaseResponse>(null);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                validationResponse.Message = errors;
                validationResponse.IsSuccess = false;
                validationResponse.Health = true;
                return validationResponse;
            }

            PurchaseMainHelper purchaseHelper = new PurchaseMainHelper(unitOfWork);
            PurchaseMainHelperResppnse purchaseResult = await purchaseHelper.Purchase(request.purchaseRequest);

            if (purchaseResult.isPurchased is not true)
            {
                validationResponse.Message = "Yetersiz bakiye!";
                return validationResponse;
            }

            UpdateProductQuantity updateProductQuantity = new UpdateProductQuantity(unitOfWork);
            decimal pointMultiplierPercentage = await updateProductQuantity.UpdateQuantity(request.purchaseRequest.BasketId);
            await unitOfWork.BasketItemWriteRepository.Delete(request.purchaseRequest.BasketId);
            UpdatePoint updatePoint = new UpdatePoint(unitOfWork);
            updatePoint.Update(request.purchaseRequest.UserId, pointMultiplierPercentage, purchaseResult.MoneytoCalculatePoint);

            return new ApiResponse<PurchaseResponse>();

        }
    }
}
