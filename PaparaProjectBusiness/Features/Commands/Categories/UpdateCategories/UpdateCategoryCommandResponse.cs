using PaparaProjectBase.APIResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Commands.Categories.UpdateCategories
{
    public class UpdateCategoryCommandResponse<CategoryResponse> : ApiResponse<CategoryResponse>
    {
        public CategoryResponse categoryResponse { get; set; }
        public UpdateCategoryCommandResponse(CategoryResponse response)
        {
            categoryResponse = response;
        }
    }
}
