using Microsoft.IdentityModel.Tokens;
using PaparaFinalData.Entity;
using PaparaProjectBase.Token;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PaparaProjectBusiness.Token
{
    public class TokenService : ITokenService
    {
        private readonly JwtConfig jwtConfig;

        public TokenService(JwtConfig jwtConfig)
        {
            this.jwtConfig = jwtConfig;
        }
        public async Task<string> GetToken(User user)
        {
            Claim[] claims = GetClaims(user);
            var secret = Encoding.ASCII.GetBytes(jwtConfig.Secret);

            JwtSecurityToken jwtToken = new JwtSecurityToken(
                jwtConfig.Issuer,
                jwtConfig.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(jwtConfig.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret),
                    SecurityAlgorithms.HmacSha256Signature)
            );

            string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return token;
        }

        private Claim[] GetClaims(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("UserName", user.UserName),
                new Claim("Role", user.Role),
                new Claim("Email", user.Email),
                new Claim("PhoneNumber", user.PhoneNumber),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Name, $"{user.Name} {user.Surname}")
            };

            return claims.ToArray();
        }
    }
}
