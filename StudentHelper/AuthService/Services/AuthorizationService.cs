using AuthService.Models;
using DbStudentHelper;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AuthService.Services
{
    public class AuthorizationService : IAuthService
    {
        private readonly StudentHelperDbContext _dbContext;
        private readonly ITokenBuilder _tokenBuilder;
        public AuthorizationService(StudentHelperDbContext dbContext, ITokenBuilder tokenBuilder)
        {
            _dbContext = dbContext;
            _tokenBuilder = tokenBuilder;
        }

        public string GenerateToken(LoginModel user)
        {
            var dbUser = _dbContext.Users.Include(u => u.Role).SingleOrDefault(u => u.Email == user.Login);

            if (dbUser == null)
            {
                throw new Exception("User not found");
            }

            var validPassword = dbUser.Password == user.Password;

            if (!validPassword)
                throw new Exception("Could not authenticate user");

            return _tokenBuilder.GenerateToken(user.Login, dbUser.Role.Role);
        }

        public int VerifyUser(List<Claim> claims, string role)
        {
            var login = claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier);

            var userRole = claims.FirstOrDefault(u => u.Type == ClaimTypes.Role);

            if (login == null)
                return StatusCodes.Status401Unauthorized;

            var userExists =  _dbContext.Users.Any(u => u.Email == login.Value);

            if (!userExists)
                return StatusCodes.Status401Unauthorized;

            if (!string.IsNullOrEmpty(role) && (userRole == null || role != userRole.Value))
                return StatusCodes.Status403Forbidden;

            return StatusCodes.Status200OK;

        }

    }
}
