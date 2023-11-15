using StudentHelper.API.Models;

namespace StudentHelper.API.Services.IServices
{
    public interface IAuthService : IBaseService
    {
        T Login<T>(LoginModel loginModel);

        T VerifyToken<T>(string token, string role);
    }
}
