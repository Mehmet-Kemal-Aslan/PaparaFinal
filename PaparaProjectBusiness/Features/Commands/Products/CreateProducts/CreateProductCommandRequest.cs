using MediatR;
using PaparaProjectBase.APIResponse;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Commands.Products.CreateProducts
{
    public class CreateProductCommandRequest : ProductRequest, IRequest<ApiResponse<ProductResponse>>
    {
        public ProductRequest productRequest { get; }
        public CreateProductCommandRequest(ProductRequest request)
        {
            productRequest = request;
        }
    }
}
