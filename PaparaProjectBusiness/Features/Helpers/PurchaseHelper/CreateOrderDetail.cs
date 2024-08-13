using AutoMapper;
using MediatR;
using PaparaFinalData.Entity;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Helpers.PurchaseHelper
{
    public class CreateOrderDetail
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public CreateOrderDetail(IUnitOfWork unitOfWork, IMediator mediator, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mediator = mediator;
            this.mapper = mapper;
        }

        public async Task<OrderDetail> Create(int orderId, int basketId)
        {
            List<BasketItem> basketItemList = await unitOfWork.BasketItemReadRepository.Where(bi => bi.BasketId == basketId);
            OrderDetail newOrderDetail = new OrderDetail
            {
                OrderId = orderId,
                BasketItems = basketItemList,
            };
            await unitOfWork.OrderDetailWriteRepository.Insert(newOrderDetail);

            return newOrderDetail;
        }
    }
}
