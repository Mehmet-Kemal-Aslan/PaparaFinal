using PaparaFinalBase.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaFinalData.Entity
{
    public class OrderDetail : BaseEntity
    {
        public int OrderId { get; set; }
        public Order Orders { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
