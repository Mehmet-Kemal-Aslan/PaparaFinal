using MediatR;
using PaparaProjectBase.APIResponse;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Commands.Categories.CreateCategories
{
    public class CreateCategoryCommandRequest : CategoryRequest, IRequest<ApiResponse<CategoryResponse>>
    {
        public CategoryRequest categoryRequest { get; }
        public CreateCategoryCommandRequest(CategoryRequest request)
        {
            categoryRequest = request;
        }
    }
}
