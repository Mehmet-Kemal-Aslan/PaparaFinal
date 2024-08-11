using AutoMapper;
using MediatR;
using PaparaFinalData.Entity;
using PaparaProjectBase.APIResponse;
using PaparaProjectBusiness.Features.Commands.Categories.CreateCategories;
using PaparaProjectBusiness.Validation.Validators;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Commands.Products.CreateProducts
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, ApiResponse<ProductResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<ProductResponse>> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
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
            await unitOfWork.ProductWriteRepository.Insert(mapped);
            await unitOfWork.Complete();

            var response = mapper.Map<ProductResponse>(mapped);
            return new ApiResponse<ProductResponse>(response);
        }
    }
}
