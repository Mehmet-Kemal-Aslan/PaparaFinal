using AutoMapper;
using MediatR;
using PaparaFinalData.Entity;
using PaparaProjectBusiness.Features.Queries.Wallets.GetAllWallets;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Queries.Categories.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, GetAllCategoriesQueryResponse<List<CategoryResponse>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<GetAllCategoriesQueryResponse<List<CategoryResponse>>> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            List<Category> categoryList = await unitOfWork.CategoryReadRepository.GetAll();
            List<CategoryResponse> mappedList = mapper.Map<List<CategoryResponse>>(categoryList);
            return new GetAllCategoriesQueryResponse<List<CategoryResponse>>(mappedList);
        }
    }
}
