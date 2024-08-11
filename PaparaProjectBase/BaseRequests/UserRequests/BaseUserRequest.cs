using PaparaProjectSchema.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBase.BaseRequests.UserRequests
{
    public class BaseUserRequest
    {
        public UserRequest Request { get; }

        public BaseUserRequest(UserRequest request)
        {
            Request = request;
        }
    }
}
