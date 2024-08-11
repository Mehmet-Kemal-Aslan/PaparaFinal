using PaparaFinalBase.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaFinalData.Entity
{
    public class BasketItem : BaseEntity
    {
        public int BasketId { get; set; }
        public int ProductId { get; set; }
        public int? OrderDetailId { get; set; }
        public int Quantity { get; set; }
        public Basket Baskets { get; set; }
        public Product Products { get; set; }
        public OrderDetail OrderDetails { get; set; }
    }
}
