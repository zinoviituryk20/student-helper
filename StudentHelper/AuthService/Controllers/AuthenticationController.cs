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
        protected ResponseDto _response;
        private readonly IAuthService _authService;
        public AuthenticationController(IAuthService authService)
        {
            _response = new ResponseDto();
            _authService = authService;
        }

        [HttpPost("auth")]
        public object Login([FromBody] LoginModel user)
        {
            try
            {
                var token = _authService.GenerateToken(user);
                _response.Result = token;
            }
            catch (Exception ex)
            {
                _response.DisplayMessage = "Error";
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;

        }
        [HttpGet("verify")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public object VerifyToken(string role = null)
        {
            try
            {
                var result = _authService.VerifyUser(User.Claims.ToList(), role);
                if (result != 200)
                    throw new Exception(result.ToString());
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }
    }
}
