using PaparaProjectBase.APIResponse;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Queries.Categories.GetAllCategories
{
    public class GetAllCategoriesQueryResponse<CategoryResponseList> : ApiResponse<CategoryResponse>
    {
        public List<CategoryResponse> Categories { get; set; }
        public GetAllCategoriesQueryResponse(List<CategoryResponse> categoryList)
        {
            Categories = categoryList;
        }
    }
}
