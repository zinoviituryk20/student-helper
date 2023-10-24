using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentHelper.User.API.Models;
using StudentHelper.User.API.Repository;
using System.Collections.Generic;

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
        public IEnumerable<UserDto> GetUsers()
        {
            var result = _userRepository.GetUsers();
            return result;
        }

        [HttpGet]

        public UserDto GetUserById(int id)
        {
            var result = _userRepository.GetUser(id);
            return result;
        }

        [HttpPost]
        public UserDto CreateUpdateUser(UserDto user)
        {
            var result = _userRepository.CreateUpdateUser(user);
            return result;
        }

        [HttpDelete]
        public ActionResult DeleteUserById(int userId)
        {
            var isDelete = _userRepository.DeleteUser(userId);

            if (isDelete)
                return Ok();
            else
                return NotFound();
        }
    }
}
