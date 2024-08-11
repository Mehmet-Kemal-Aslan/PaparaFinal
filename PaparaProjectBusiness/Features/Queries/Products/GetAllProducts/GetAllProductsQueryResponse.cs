using PaparaProjectBase.APIResponse;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Queries.Products.GetAllProducts
{
    public class GetAllProductsQueryResponse<ProductResponseList> : ApiResponse<ProductResponse>
    {
        public List<ProductResponse> Products { get; set; }
        public GetAllProductsQueryResponse(List<ProductResponse> productList)
        {
            Products = productList;
        }
    }
}
