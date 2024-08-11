using AutoMapper;
using MediatR;
using PaparaFinalData.Entity;
using PaparaProjectBase.APIResponse;
using PaparaProjectBusiness.Features.Commands.Wallets.CreateWallet;
using PaparaProjectBusiness.Validation.Validators;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Commands.Categories.CreateCategories
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, ApiResponse<CategoryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<CategoryResponse>> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
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
            await unitOfWork.CategoryWriteRepository.Insert(mapped);
            await unitOfWork.Complete();

            var response = mapper.Map<CategoryResponse>(mapped);
            return new ApiResponse<CategoryResponse>(response);
        }
    }
}
