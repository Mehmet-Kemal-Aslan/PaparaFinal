using PaparaProjectBase.APIResponse;
using PaparaProjectSchema.Responses;
namespace PaparaProjectBusiness.Features.Commands.Categories.DeleteCategories
{
    public class DeleteCategoryCommandResponse : APIDeleteResponse
    {
        public CategoryResponse categoryResponse { get; set; }
        public DeleteCategoryCommandResponse(CategoryResponse response)
        {
            categoryResponse = response;
        }
    }
}
