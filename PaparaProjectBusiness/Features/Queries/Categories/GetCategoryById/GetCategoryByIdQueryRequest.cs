using MediatR;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Queries.Categories.GetCategoryById
{
    public class GetCategoryByIdQueryRequest(int categoryId) : IRequest<GetCategoryByIdQueryResponse<CategoryResponse>>
    {
        public int CategoryId = categoryId;
    }
}
