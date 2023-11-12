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
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public UserDto GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }

        [HttpPost]
        public UserDto UpdateUserInfo(UserDto userDto)
        {
            return _userRepository.UpdateUserInfo(userDto);
        }
    }
}
