using MediatR;
using PaparaProjectBase.APIResponse;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Commands.Purchase.Purchase
{
    public class CreatePurchaseCommandRequest : OrderResponse, IRequest<ApiResponse<OrderResponse>>
    {
        public PurchaseRequest purchaseRequest { get; }
        public CreatePurchaseCommandRequest(PurchaseRequest request)
        {
            purchaseRequest = request;
        }
    }
}
