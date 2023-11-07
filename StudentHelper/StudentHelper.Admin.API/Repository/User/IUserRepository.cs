using StudentHelper.Admin.API.Models;

namespace StudentHelper.Admin.API.Repository
{
    public interface IUserRepository
    {
        IEnumerable<UserDto> GetUsers();

        UserDto GetUser(int userid);

        UserDto CreateUpdateUser(UserDto userDto);

        bool DeleteUser(int userId);
    }
}
