using AutoMapper;
using MediatR;
using PaparaFinalData.Entity;
using PaparaProjectBase.Models.Messages;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Queries.Products.GetProductsByCategory
{
    public class GetProductsByCategoryHandler : IRequestHandler<GetProductsByCategoryRequest, GetProductsByCategoryResponse<ProductResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetProductsByCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<GetProductsByCategoryResponse<ProductResponse>> Handle(GetProductsByCategoryRequest request, CancellationToken cancellationToken)
        {
            List<Product> productList = await unitOfWork.ProductReadRepository.Where(w => w.ProductCategoryMaps.Any(pcm => pcm.CategoryId == request.CategoryId));
            if (productList == null || !productList.Any())
            {
                GetProductsByCategoryResponse<ProductResponse> nullResponse = new GetProductsByCategoryResponse<ProductResponse>(null);
                nullResponse.Message = ResponseMessages.NotFound;
                return nullResponse;
            }
            List<ProductResponse> mappedWallets = mapper.Map<List<ProductResponse>>(productList);
            return new GetProductsByCategoryResponse<ProductResponse>(mappedWallets);
        }
    }
}
