using PaparaFinalBase.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaFinalData.Entity
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
        public User Users { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal? CouponPrice { get; set; }
        public int? CouponCode { get; set; }
        public decimal? Point { get; set; }
        public string Address { get; set; }
        public DateTime DateTime { get; set; }
        public int? BasketId { get; set; }
        public Basket Baskets { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
