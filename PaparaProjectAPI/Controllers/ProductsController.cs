using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaparaProjectBase.APIResponse;
using PaparaProjectBusiness.Features.Commands.Products.CreateProducts;
using PaparaProjectBusiness.Features.Commands.Products.DeleteProducts;
using PaparaProjectBusiness.Features.Commands.Products.UpdateProducts;
using PaparaProjectBusiness.Features.Queries.Products.GetAllProducts;
using PaparaProjectBusiness.Features.Queries.Products.GetProductsByCategory;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;

namespace PaparaProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        //[Authorize(Roles = "admin")]
        public async Task<GetAllProductsQueryResponse<List<ProductResponse>>> GetAll()
        {
            GetAllProductsQueryRequest operation = new GetAllProductsQueryRequest();
            GetAllProductsQueryResponse<List<ProductResponse>> result = await mediator.Send(operation);
            return result;
        }

        [HttpGet("{categoryId}")]
        //[Authorize(Roles = "admin")]
        public async Task<GetProductsByCategoryResponse<ProductResponse>> GetBycategory([FromRoute] int categoryId)
        {
            GetProductsByCategoryRequest operation = new GetProductsByCategoryRequest(categoryId);
            GetProductsByCategoryResponse<ProductResponse> result = await mediator.Send(operation);
            return result;
        }

        [HttpPost]
        //[Authorize(Roles = "admin")]
        public async Task<ApiResponse<ProductResponse>> Post([FromBody] ProductRequest value)
        {
            CreateProductCommandRequest operation = new CreateProductCommandRequest(value);
            ApiResponse<ProductResponse> result = await mediator.Send(operation);
            return result;
        }

        [HttpPut("{productId}")]
        //[Authorize(Roles = "admin")]
        public async Task<ApiResponse<ProductResponse>> Put(int productId, [FromBody] ProductRequest value)
        {
            UpdateProductCommandRequest operation = new UpdateProductCommandRequest(productId, value);
            ApiResponse<ProductResponse> result = await mediator.Send(operation);
            return result;
        }

        [HttpDelete("{productId}")]
        //[authorize(roles = "admin")]
        public async Task<APIDeleteResponse> Delete(int productId)
        {
            DeleteProductCommandRequest operation = new DeleteProductCommandRequest(productId);
            APIDeleteResponse result = await mediator.Send(operation);
            return result;
        }
    }
}
