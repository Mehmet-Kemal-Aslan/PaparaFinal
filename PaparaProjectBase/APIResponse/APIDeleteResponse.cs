using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBase.APIResponse
{
    public class APIDeleteResponse
    {
        public string Message { get; set; }
        public APIDeleteResponse() 
        {
            Message = "Silindi!";
        }
    }
}
