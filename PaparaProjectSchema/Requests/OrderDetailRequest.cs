using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectSchema.Requests
{
    public class OrderDetailRequest
    {
        public int OrderId { get; set; }
        public ICollection<BasketItemRequest> BasketItems { get; set; }
    }
}
