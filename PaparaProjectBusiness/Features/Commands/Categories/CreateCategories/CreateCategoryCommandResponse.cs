using PaparaProjectBase.APIResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Commands.Categories.CreateCategories
{
    public class CreateCategoryCommandResponse<CategoryResponse> : ApiResponse<CategoryResponse>
    {
        public CategoryResponse categoryResponse { get; set; }
        public CreateCategoryCommandResponse(CategoryResponse response)
        {
            categoryResponse = response;
        }
    }
}

