using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectSchema.Requests
{
    public class PurchaseRequest
    {
        public int UserId { get; set; }
        public int BasketId { get; set; }
        public string CardNumber { get; set; } 
        public string CardName { get; set;}
        public DateOnly CardExpireDate { get; set; }
        public int CVV { get; set;}
        public string? CouponCode { get; set; }
    }
}
