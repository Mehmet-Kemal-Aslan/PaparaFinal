using MediatR;
using PaparaProjectBase.APIResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Commands.Products.DeleteProducts
{
    public class DeleteProductCommandRequest(int productId) : IRequest<APIDeleteResponse>
    {
        public int ProductId = productId;
    }
}
