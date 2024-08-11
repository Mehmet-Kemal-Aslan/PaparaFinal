using PaparaProjectBase.APIResponse;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Commands.Products.DeleteProducts
{
    public class DeleteProductCommandResponse : APIDeleteResponse
    {
        public ProductResponse productResponse { get; set; }
        public DeleteProductCommandResponse(ProductResponse response)
        {
            productResponse = response;
        }
    }
}
