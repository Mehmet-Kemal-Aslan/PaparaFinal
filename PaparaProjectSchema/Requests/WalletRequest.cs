using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectSchema.Requests
{
    public class WalletRequest
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        public decimal Money { get; set; }
        public int UserId { get; set; }
    }
}
