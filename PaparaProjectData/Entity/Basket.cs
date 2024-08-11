using PaparaFinalBase.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaFinalData.Entity
{
    public class Basket : BaseEntity
    { 
        public string UserId {  get; set; }
        public User Users { get; set; }
        public int? OrderId { get; set; }
        public Order? Orders { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
