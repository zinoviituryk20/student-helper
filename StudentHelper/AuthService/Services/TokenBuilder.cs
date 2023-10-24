using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.Services
{
    public class TokenBuilder : ITokenBuilder
    {
        public string GenerateToken(string userName, string role)
        {
            var signKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("0133258A-6ACD-42ED-9BFB-1AD1B455605E"));
            var signCreds = new SigningCredentials(signKey,SecurityAlgorithms.HmacSha256);
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,userName),
                new Claim(ClaimTypes.Role,role)
            };
            var jwt = new JwtSecurityToken(claims:claims,signingCredentials:signCreds);
            var encJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encJwt;
        }
    }
}
