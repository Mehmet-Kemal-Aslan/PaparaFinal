using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaparaProjectBase.APIResponse;
using PaparaProjectBusiness.Features.Commands.Coupons.CreateCoupons;
using PaparaProjectBusiness.Features.Commands.Coupons.DeleteCoupons;
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
        [Authorize(Roles = "Admin,Normal")]
        public async Task<GetAllCouponsQueryResponse<List<CouponResponse>>> GetAll()
        {
            GetAllCouponsQueryRequest operation = new GetAllCouponsQueryRequest();
            GetAllCouponsQueryResponse<List<CouponResponse>> result = await mediator.Send(operation);
            return result;
        }

        [HttpGet("{couponId}")]
        [Authorize(Roles = "Admin,Normal")]
        public async Task<GetCouponByIdQueryResponse<CouponResponse>> Get([FromRoute] int couponId)
        {
            GetCouponByIdQueryRequest operation = new GetCouponByIdQueryRequest(couponId);
            GetCouponByIdQueryResponse<CouponResponse> result = await mediator.Send(operation);
            return result;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ApiResponse<CouponResponse>> Post([FromBody] CouponRequest value)
        {
            CreateCouponCommandRequest operation = new CreateCouponCommandRequest(value);
            ApiResponse<CouponResponse> result = await mediator.Send(operation);
            return result;
        }

        [HttpDelete("{couponId}")]
        [Authorize(Roles = "Admin")]
        public async Task<APIDeleteResponse> Delete(int couponId)
        {
            DeleteCouponCommandRequest operation = new DeleteCouponCommandRequest(couponId);
            APIDeleteResponse result = await mediator.Send(operation);
            return result;
        }
    }
}
