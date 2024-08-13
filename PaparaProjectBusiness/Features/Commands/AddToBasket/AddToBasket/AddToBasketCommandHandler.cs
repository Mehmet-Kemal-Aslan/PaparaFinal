using AutoMapper;
using MediatR;
using PaparaFinalData.Entity;
using PaparaProjectBase.APIResponse;
using PaparaProjectBusiness.Validation.Validators;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Commands.AddToBasket.AddToBasket
{
    public class AddToBasketCommandHandler : IRequestHandler<AddToBasketCommandRequest, ApiResponse<BasketResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AddToBasketCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<BasketResponse>> Handle(AddToBasketCommandRequest request, CancellationToken cancellationToken)
        {
            AddToBasketValidator addToBasketValidator = new AddToBasketValidator();
            var validationResult = await addToBasketValidator.ValidateAsync(request.addToBasketRequest);
            ApiResponse<BasketResponse> validationResponse = new ApiResponse<BasketResponse>(null);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                validationResponse.Message = errors;
                validationResponse.IsSuccess = false;
                validationResponse.Health = true;
                return validationResponse;
            }

            Basket basket = await unitOfWork.BasketReadRepository.FirstOrDefault(b => b.UserId == request.addToBasketRequest.UserId);
            if (basket == null || basket.IsActive == false)
            {
                basket = new Basket { UserId = request.addToBasketRequest.UserId };
                await unitOfWork.BasketWriteRepository.Insert(basket);
                await unitOfWork.Complete();
                basket = await unitOfWork.BasketReadRepository.FirstOrDefault(b => b.UserId == request.addToBasketRequest.UserId);
            }
            BasketItem basketItem = new BasketItem
            {
                BasketId = basket.Id,
                ProductId = request.addToBasketRequest.ProductId,
                Quantity = request.addToBasketRequest.Quantity,
            };
            await unitOfWork.BasketItemWriteRepository.Insert(basketItem);
            await unitOfWork.Complete();

            List<BasketItem> basketItemList = await unitOfWork.BasketItemReadRepository.Where(bi => bi.BasketId == basket.Id);
            List<decimal> productPriceList = new List<decimal>();
            decimal price = 0;
            foreach (BasketItem item in basketItemList)
            {
                Product newProduct = await unitOfWork.ProductReadRepository.FirstOrDefault(p => p.Id == item.ProductId);
                //productPriceList.Append(newProduct.Price * item.Quantity);
                price = price + newProduct.Price * item.Quantity;
            }
            basket.Price = price;
            unitOfWork.BasketWriteRepository.Update(basket);
            await unitOfWork.Complete();

            var mappedBasketItemList = mapper.Map<List<BasketItem>,List<BasketItemResponse>>(basketItemList);
            BasketResponse basketResponse = new BasketResponse()
            {
                UserId = request.UserId,
                BasketItems = mappedBasketItemList,
                BasketPrice = price
            };
            return new ApiResponse<BasketResponse>(basketResponse);
        }
    }
}
