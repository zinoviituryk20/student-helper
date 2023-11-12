using StudentHelper.User.API.Models;

namespace StudentHelper.User.API.Repository
{
    public interface IUserRepository
    {
        UserDto GetUserById(int userId);

        UserDto UpdateUserInfo(UserDto userDto);
    }
}
