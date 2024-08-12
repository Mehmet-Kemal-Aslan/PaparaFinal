using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaparaProjectBusiness.Features.Queries.Categories.GetCategoryById;
using PaparaProjectBusiness.Features.Queries.UserPoint;
using PaparaProjectSchema.Responses;

namespace PaparaProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private readonly IMediator mediator;

        public PointController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{userId}")]
        //[Authorize(Roles = "admin")]
        public async Task<GetPointByUserIdQueryResponse<PointResponse>> Get([FromRoute] int userId)
        {
            GetPointByUserIdQueryRequest operation = new GetPointByUserIdQueryRequest(userId);
            GetPointByUserIdQueryResponse<PointResponse> result = await mediator.Send(operation);
            return result;
        }
    }
}
