using StudentHelper.User.API.Models;

namespace StudentHelper.User.API.Repository
{
    public interface IUserRepository
    {
        IEnumerable<UserDto> GetUsers();

        UserDto GetUser(int userid);

        UserDto CreateUpdateUser(UserDto userDto);

        bool DeleteUser(int userId);
    }
}
