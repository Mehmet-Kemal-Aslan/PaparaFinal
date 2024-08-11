using PaparaFinalBase.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaFinalData.Entity
{
    public class Wallet : BaseEntity
    {
        //public string Name { get; set; }
        public decimal Money {  get; set; }
        public string UserId { get; set; }
        public User Users { get; set; }
    }
}
