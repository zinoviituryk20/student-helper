using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentHelper.API.Filters;
using StudentHelper.API.Models;
using StudentHelper.API.Services.IServices;

namespace StudentHelper.API.Controllers
{
    [SHAuthorization()]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userService;
        private readonly IAuthService _authService;
        public UserController(IUserServices userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            ResponseDto response = _authService.Login<ResponseDto>(loginModel);
            if (response.IsSuccess)
                return Ok(response.Result);
            else
                return BadRequest();
        }
        [HttpGet]
        public UserDto GetUser(int id) 
        {
            var user = new UserDto();

            ResponseDto response = _userService.GetUser<ResponseDto>(id);

            if(response != null && response.IsSuccess)
                user = JsonConvert.DeserializeObject<UserDto>(response.Result.ToString());

            return user;

        }

        [HttpPut]
        public UserDto UpdateUserInfo(UserDto userDto)
        {
            var updateUser = new UserDto();
            
            var response = _userService.UpdateUser<ResponseDto>(updateUser);

            if (response != null && response.IsSuccess)
                updateUser = JsonConvert.DeserializeObject<UserDto>(response.Result.ToString());

            return updateUser;
        }
    }
}
