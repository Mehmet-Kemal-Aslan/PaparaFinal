using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectSchema.Requests
{
    public class InvoiceRequest
    {
        public decimal Price { get; set; }
        public string UserId { get; set; }
    }
}
