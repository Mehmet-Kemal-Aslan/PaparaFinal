using AutoMapper;
using MediatR;
using PaparaFinalData.Entity;
using PaparaProjectBase.APIResponse;
using PaparaProjectBusiness.Features.Queries.Wallets.GetWalletById;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Queries.Categories.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQueryRequest, GetCategoryByIdQueryResponse<CategoryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<GetCategoryByIdQueryResponse<CategoryResponse>> Handle(GetCategoryByIdQueryRequest request, CancellationToken cancellationToken)
        {
            Category category = await unitOfWork.CategoryReadRepository.GetById(request.CategoryId);
            if (category == null)
            {
                GetCategoryByIdQueryResponse<CategoryResponse> nullResponse = new GetCategoryByIdQueryResponse<CategoryResponse>(null);
                nullResponse.Message = "Bulunamadı!";
                return nullResponse;
            }
            CategoryResponse mappedCategories = mapper.Map< CategoryResponse>(category);
            return new GetCategoryByIdQueryResponse<CategoryResponse>(mappedCategories);
        }
    }
}
