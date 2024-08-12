using Microsoft.AspNetCore.Http;

namespace PaparaProjectBase.Session
{
    public class SessionContext : ISessionContext
    {
        public HttpContext HttpContext { get; set; }
        public Session Session { get; set; }
    }
}
