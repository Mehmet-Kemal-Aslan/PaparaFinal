using PaparaProjectBase.APIResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Commands.Products.UpdateProducts
{
    public class UpdateProductCommandResponse<ProductResponse> : ApiResponse<ProductResponse>
    {
        public ProductResponse productResponse { get; set; }
        public UpdateProductCommandResponse(ProductResponse response)
        {
            productResponse = response;
        }
    }
}
