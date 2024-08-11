using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectSchema.Requests
{
    public class OrderRequest
    {
        public string UserId { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal? CouponPrice { get; set; }
        public int? CouponCode { get; set; }
        public decimal? Point { get; set; }
        public string Address { get; set; }
        public DateTime DateTime { get; set; }
        public int? BasketId { get; set; }
        public ICollection<OrderDetailRequest> OrderDetails { get; set; }
    }
}
