using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaparaProjectBase.APIResponse;
using PaparaProjectBusiness.Features.Commands.Categories.CreateCategories;
using PaparaProjectBusiness.Features.Commands.Categories.DeleteCategories;
using PaparaProjectBusiness.Features.Commands.Categories.UpdateCategories;
using PaparaProjectBusiness.Features.Queries.Categories.GetAllCategories;
using PaparaProjectBusiness.Features.Queries.Categories.GetCategoryById;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;

namespace PaparaProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<GetAllCategoriesQueryResponse<List<CategoryResponse>>> GetAll()
        {
            GetAllCategoriesQueryRequest operation = new GetAllCategoriesQueryRequest();
            GetAllCategoriesQueryResponse<List<CategoryResponse>> result = await mediator.Send(operation);
            return result;
        }

        [HttpGet("{categoryId}")]
        public async Task<GetCategoryByIdQueryResponse<CategoryResponse>> Get([FromRoute] int categoryId)
        {
            GetCategoryByIdQueryRequest operation = new GetCategoryByIdQueryRequest(categoryId);
            GetCategoryByIdQueryResponse<CategoryResponse> result = await mediator.Send(operation);
            return result;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ApiResponse<CategoryResponse>> Post([FromBody] CategoryRequest value)
        {
            CreateCategoryCommandRequest operation = new CreateCategoryCommandRequest(value);
            ApiResponse<CategoryResponse> result = await mediator.Send(operation);
            return result;
        }

        [HttpPut("{categoryId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ApiResponse<CategoryResponse>> Put(int categoryId, [FromBody] CategoryRequest value)
        {
            UpdateCategoryCommandRequest operation = new UpdateCategoryCommandRequest(categoryId, value);
            ApiResponse<CategoryResponse> result = await mediator.Send(operation);
            return result;
        }

        [HttpDelete("{categoryId}")]
        [Authorize(Roles = "Admin")]
        public async Task<APIDeleteResponse> Delete(int categoryId)
        {
            DeleteCategoryCommandRequest operation = new DeleteCategoryCommandRequest(categoryId);
            APIDeleteResponse result = await mediator.Send(operation);
            return result;
        }
    }
}
