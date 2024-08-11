using PaparaProjectSchema.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectSchema.Responses
{
    public class OrderDetailResponse
    {
        public int OrderId { get; set; }
        public ICollection<BasketItemResponse> BasketItems { get; set; }
    }
}
