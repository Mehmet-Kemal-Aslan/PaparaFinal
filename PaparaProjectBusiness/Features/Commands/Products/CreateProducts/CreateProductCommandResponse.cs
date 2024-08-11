using PaparaProjectBase.APIResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Commands.Products.CreateProducts
{
    public class CreateProductCommandResponse<ProductResponse> : ApiResponse<ProductResponse>
    {
        public ProductResponse productResponse { get; set; }
        public CreateProductCommandResponse(ProductResponse response)
        {
            productResponse = response;
        }
    }
}
