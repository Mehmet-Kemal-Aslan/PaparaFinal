using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectSchema.Responses
{
    public class CouponResponse
    {
        public string Code { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
