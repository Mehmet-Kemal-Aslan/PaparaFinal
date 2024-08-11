using AutoMapper;
using MediatR;
using PaparaFinalData.Entity;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Queries.Products.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, GetAllProductsQueryResponse<List<ProductResponse>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<GetAllProductsQueryResponse<List<ProductResponse>>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            List<Product> productList = await unitOfWork.ProductReadRepository.GetAll();
            List<ProductResponse> mappedList = mapper.Map<List<ProductResponse>>(productList);
            return new GetAllProductsQueryResponse<List<ProductResponse>>(mappedList);
        }
    }
}
