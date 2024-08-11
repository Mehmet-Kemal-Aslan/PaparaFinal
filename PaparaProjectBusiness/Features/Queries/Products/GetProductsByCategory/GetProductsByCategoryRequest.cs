using MediatR;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Queries.Products.GetProductsByCategory
{
    public class GetProductsByCategoryRequest(int categoryId) : IRequest<GetProductsByCategoryResponse<ProductResponse>>
    {
        public int CategoryId = categoryId;
    }
}
