using MediatR;
using PaparaProjectBase.APIResponse;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Commands.Products.UpdateProducts
{
    public class UpdateProductCommandRequest : ProductRequest, IRequest<ApiResponse<ProductResponse>>
    {
        public ProductRequest productRequest { get; }
        public int productId { get; }
        public UpdateProductCommandRequest(int Id, ProductRequest request)
        {
            productRequest = request;
            productId = Id;
        }
    }
}
