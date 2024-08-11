using MediatR;
using PaparaProjectBase.APIResponse;

namespace PaparaProjectBusiness.Features.Commands.Categories.DeleteCategories
{
    public class DeleteCategoryCommandRequest(int categoryId) : IRequest<APIDeleteResponse>
    {
        public int CategoryId = categoryId;
    }
}
