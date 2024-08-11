using MediatR;
using PaparaProjectBase.APIResponse;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Commands.Categories.UpdateCategories
{
    public class UpdateCategoryCommandRequest : CategoryRequest, IRequest<ApiResponse<CategoryResponse>>
    {
        public CategoryRequest categoryRequest { get; }
        public int categoryId { get; }
        public UpdateCategoryCommandRequest(int Id, CategoryRequest request)
        {
            categoryRequest = request;
            categoryId = Id;
        }
    }
}
