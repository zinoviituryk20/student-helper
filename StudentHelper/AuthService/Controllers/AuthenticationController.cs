using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DbStudentHelper;
using AuthService.Services;
using DbStudentHelper.Data;
using Microsoft.EntityFrameworkCore;
using AuthService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("auth")]
        public async Task<ActionResult> Login([FromBody] LoginModel user)
        {
            try
            {
                var token = _authService.GenerateToken(user);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("verify")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> VerifyToken(string role)
        {
            var result = _authService.VerifyUser(User.Claims.ToList(), role);

            return new StatusCodeResult(result);
        }
    }
}
