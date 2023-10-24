using AuthService.Models;
using System.Security.Claims;

namespace AuthService.Services
{
    public interface IAuthService
    {
        string GenerateToken(LoginModel user);

        int VerifyUser(List<Claim> claims, string role);
    }
}
