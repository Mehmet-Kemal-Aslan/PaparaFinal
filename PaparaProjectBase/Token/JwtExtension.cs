using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace PaparaProjectBase.Token
{
    public static class JwtExtension
    {
        public static Session.Session GetSession(HttpContext context)
        {
            Session.Session session = new Session.Session();
            var identity = context.User.Identity as ClaimsIdentity;
            var claims = identity.Claims;
            session.UserName = GetClaimValue(claims, "UserName");
            session.Role = GetClaimValue(claims, "Role");
            session.Email = GetClaimValue(claims, "Email");
            session.PhoneNumber = GetClaimValue(claims, "PhoneNumber");
            return session;
        }

        private static string GetClaimValue(IEnumerable<Claim> claims, string name)
        {
            var claim = claims.FirstOrDefault(c => c.Type == name);
            return claim?.Value;
        }
    }
}
