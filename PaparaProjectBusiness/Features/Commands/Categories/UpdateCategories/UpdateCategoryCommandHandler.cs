using AutoMapper;
using MediatR;
using PaparaFinalData.Entity;
using PaparaProjectBase.APIResponse;
using PaparaProjectBusiness.Features.Commands.Wallets.UpdateWallet;
using PaparaProjectBusiness.Validation.Validators;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Commands.Categories.UpdateCategories
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, ApiResponse<CategoryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<CategoryResponse>> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            var validationResult = await categoryValidator.ValidateAsync(request.categoryRequest);
            ApiResponse<CategoryResponse> validationResponse = new ApiResponse<CategoryResponse>(null);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                validationResponse.Message = errors;
                validationResponse.IsSuccess = false;
                validationResponse.Health = true;
                return validationResponse;
            }

            var mapped = mapper.Map<CategoryRequest, Category>(request.categoryRequest);
            mapped.Id = request.categoryId; 
            unitOfWork.CategoryWriteRepository.Update(mapped);
            await unitOfWork.Complete();

            var response = mapper.Map<CategoryResponse>(mapped);
            return new ApiResponse<CategoryResponse>(response);
        }
    }
}
