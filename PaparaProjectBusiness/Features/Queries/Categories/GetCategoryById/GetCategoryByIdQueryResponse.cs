using PaparaProjectBase.APIResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Queries.Categories.GetCategoryById
{
    public class GetCategoryByIdQueryResponse<CategoryResponse> : ApiResponse<CategoryResponse>
    {
        public CategoryResponse Category { get; set; }
        public GetCategoryByIdQueryResponse(CategoryResponse category)
        {
            Category = category;
        }
    }
}
