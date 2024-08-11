using AutoMapper;
using MediatR;
using PaparaFinalData.Entity;
using PaparaProjectBase.APIResponse;
using PaparaProjectBusiness.Validation.Validators;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Commands.Products.UpdateProducts
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, ApiResponse<ProductResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<ProductResponse>> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            ProductValidator productValidator = new ProductValidator();
            var validationResult = await productValidator.ValidateAsync(request.productRequest);
            ApiResponse<ProductResponse> validationResponse = new ApiResponse<ProductResponse>(null);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                validationResponse.Message = errors;
                validationResponse.IsSuccess = false;
                validationResponse.Health = true;
                return validationResponse;
            }

            var mapped = mapper.Map<ProductRequest, Product>(request.productRequest);
            mapped.Id = request.productId;
            unitOfWork.ProductWriteRepository.Update(mapped);
            await unitOfWork.Complete();

            var response = mapper.Map<ProductResponse>(mapped);
            return new ApiResponse<ProductResponse>(response);
        }
    }
}
