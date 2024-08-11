using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectSchema.Responses
{
    public class BasketResponse
    {
        public string UserId { get; set; }
        public int? OrderId { get; set; }
        public ICollection<BasketItemResponse> BasketItems { get; set; }
    }
}
