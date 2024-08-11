using PaparaProjectBase.APIResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Queries.Products.GetProductsByCategory
{
    public class GetProductsByCategoryResponse<ProductResponse> : ApiResponse<ProductResponse>
    {
        public List<ProductResponse> Products { get; set; }
        public GetProductsByCategoryResponse(List<ProductResponse> productList)
        {
            Products = productList;
        }
    }
}
