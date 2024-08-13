using AutoMapper;
using MediatR;
using PaparaProjectBase.APIResponse;
using PaparaProjectBase.Models.Messages;
using PaparaProjectBusiness.Features.Helpers.PurchaseHelper;
using PaparaProjectBusiness.Features.Helpers.PurchaseHelper.Model;
using PaparaProjectBusiness.Validation.Validators;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Commands.Purchase.Purchase
{
    public class CreatePurchaseCommandHandler : IRequestHandler<CreatePurchaseCommandRequest, ApiResponse<OrderResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public CreatePurchaseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.mediator = mediator;
        }

        public async Task<ApiResponse<OrderResponse>> Handle(CreatePurchaseCommandRequest request, CancellationToken cancellationToken)
        {
            PurchaseValidator purchaseValidator = new PurchaseValidator();
            var validationResult = await purchaseValidator.ValidateAsync(request.purchaseRequest);
            ApiResponse<OrderResponse> validationResponse = new ApiResponse<OrderResponse>(null);
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
                validationResponse.Message = ResponseMessages.InsufficientFund;
                return validationResponse;
            }

            UpdateProductQuantity updateProductQuantity = new UpdateProductQuantity(unitOfWork);
            decimal pointMultiplierPercentage = await updateProductQuantity.UpdateQuantity(request.purchaseRequest.BasketId);
            await unitOfWork.BasketItemWriteRepository.Delete(request.purchaseRequest.BasketId);
            UpdatePoint updatePoint = new UpdatePoint(unitOfWork);
            CreateOrder createOrder = new CreateOrder(unitOfWork, mediator, mapper);
            OrderResponse orderResponse = await createOrder.Create(request.purchaseRequest.UserId, request.purchaseRequest.BasketId);
            await unitOfWork.Complete();

            return new ApiResponse<OrderResponse>(orderResponse);
        }
    }
}
