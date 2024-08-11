using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaparaProjectBase.APIResponse;
using PaparaProjectBusiness.Features.Commands.Categories.CreateCategories;
using PaparaProjectBusiness.Features.Commands.Categories.DeleteCategories;
using PaparaProjectBusiness.Features.Commands.Categories.UpdateCategories;
using PaparaProjectBusiness.Features.Commands.Coupons.CreateCoupons;
using PaparaProjectBusiness.Features.Commands.Coupons.DeleteCoupons;
using PaparaProjectBusiness.Features.Commands.Coupons.UpdateCoupons;
using PaparaProjectBusiness.Features.Queries.Categories.GetAllCategories;
using PaparaProjectBusiness.Features.Queries.Categories.GetCategoryById;
using PaparaProjectBusiness.Features.Queries.Coupons.GetAllCoupons;
using PaparaProjectBusiness.Features.Queries.Coupons.GetCouponById;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;

namespace PaparaProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly IMediator mediator;

        public CouponsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        //[Authorize(Roles = "admin")]
        public async Task<GetAllCouponsQueryResponse<List<CouponResponse>>> GetAll()
        {
            GetAllCouponsQueryRequest operation = new GetAllCouponsQueryRequest();
            GetAllCouponsQueryResponse<List<CouponResponse>> result = await mediator.Send(operation);
            return result;
        }

        [HttpGet("{couponId}")]
        //[Authorize(Roles = "admin")]
        public async Task<GetCouponByIdQueryResponse<CouponResponse>> Get([FromRoute] int couponId)
        {
            GetCouponByIdQueryRequest operation = new GetCouponByIdQueryRequest(couponId);
            GetCouponByIdQueryResponse<CouponResponse> result = await mediator.Send(operation);
            return result;
        }

        [HttpPost]
        //[Authorize(Roles = "admin")]
        public async Task<ApiResponse<CouponResponse>> Post([FromBody] CouponRequest value)
        {
            CreateCouponCommandRequest operation = new CreateCouponCommandRequest(value);
            ApiResponse<CouponResponse> result = await mediator.Send(operation);
            return result;
        }

        [HttpPut("{couponId}")]
        //[Authorize(Roles = "admin")]
        public async Task<ApiResponse<CouponResponse>> Put(int couponId, [FromBody] CouponRequest value)
        {
            UpdateCouponCommandRequest operation = new UpdateCouponCommandRequest(couponId, value);
            ApiResponse<CouponResponse> result = await mediator.Send(operation);
            return result;
        }

        [HttpDelete("{couponId}")]
        //[authorize(roles = "admin")]
        public async Task<APIDeleteResponse> Delete(int couponId)
        {
            DeleteCouponCommandRequest operation = new DeleteCouponCommandRequest(couponId);
            APIDeleteResponse result = await mediator.Send(operation);
            return result;
        }
    }
}
