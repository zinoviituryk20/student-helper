using StudentHelper.API.Models;

namespace StudentHelper.API.Services.IServices
{
    public interface IUserServices : IBaseService
    {

        T GetUser<T>(int id);

        T UpdateUser<T>(UserDto userDto);

    }
}
