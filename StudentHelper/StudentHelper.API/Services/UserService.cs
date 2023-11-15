using StudentHelper.API.Models;
using StudentHelper.API.Services.IServices;
using StudentHelper.API.Configuration;
namespace StudentHelper.API.Services
{
    public class UserService : BaseService, IUserServices
    {
        private readonly IHttpClientFactory _httpClient;

        public UserService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }

        public T GetUser<T>(int id)
        {
            return this.Send<T>(new ApiRequest
            {
                ApiType = ApiConfiguration.ApiType.GET,
                Url = ApiConfiguration.UserApiBase + "/api/User/GetUserById?userId=" + id
            });
        }

        public T UpdateUser<T>(UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
