using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentHelper.User.API.Models;
using StudentHelper.User.API.Repository;

namespace StudentHelper.User.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        protected ResponseDto _response;
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public object GetUserById(int userId)
        {
            try
            {
                var user = _userRepository.GetUserById(userId);
                _response.Result = user;
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>(){ ex.ToString() };

            }

            return _response;
        }

        [HttpPut]
        public object UpdateUserInfo(UserDto userDto)
        {
            try
            {
                var updateUser = _userRepository.UpdateUserInfo(userDto);
                _response.Result = updateUser;
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            return _response;
        }
    }
}
