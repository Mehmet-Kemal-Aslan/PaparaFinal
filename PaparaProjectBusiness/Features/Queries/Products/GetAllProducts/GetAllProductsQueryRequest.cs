using MediatR;
using PaparaProjectBusiness.Features.Queries.Categories.GetAllCategories;
using PaparaProjectBusiness.Features.Queries.Wallets.GetWalletById;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Queries.Products.GetAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<GetAllProductsQueryResponse<List<ProductResponse>>>
    {
    }
}
