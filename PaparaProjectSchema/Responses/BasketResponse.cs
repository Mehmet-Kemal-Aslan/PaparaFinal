using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectSchema.Responses
{
    public class BasketResponse
    {
        public int UserId { get; set; }
        public int? OrderId { get; set; }
        public List<BasketItemResponse> BasketItems { get; set; }
        public decimal BasketPrice { get; set; }
    }
}
