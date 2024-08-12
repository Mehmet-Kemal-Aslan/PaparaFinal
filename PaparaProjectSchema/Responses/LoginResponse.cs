using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectSchema.Responses
{
    public class LoginResponse
    {
        public DateTime ExpireTime { get; set; }
        public string AccessToken { get; set; }
        public string UserName { get; set; }
    }
}
