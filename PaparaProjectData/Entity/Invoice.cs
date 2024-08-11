using PaparaFinalBase.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaFinalData.Entity
{
    public class Invoice : BaseEntity
    {
        public decimal Price { get; set; }
        public string UserId { get; set; }
        public User Users { get; set; }
    }
}
