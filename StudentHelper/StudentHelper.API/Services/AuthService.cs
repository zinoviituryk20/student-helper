using Newtonsoft.Json;
using StudentHelper.API.Configuration;
using StudentHelper.API.Models;
using StudentHelper.API.Services.IServices;

namespace StudentHelper.API.Services
{
    public class AuthService : BaseService, IAuthService
    {
        public AuthService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public T Login<T>(LoginModel loginModel)
        {
            var response = this.Send<T>(new ApiRequest
            {
                ApiType = Configuration.ApiConfiguration.ApiType.POST,
                Data = loginModel,
                Url = ApiConfiguration.AuthApiBase + "/api/Authentication/auth"
            });

            return response;
        }

        public T VerifyToken<T>(string token,string role)
        {
            var response = this.Send<T>(new ApiRequest
            {
                ApiType = ApiConfiguration.ApiType.GET,
                Url = ApiConfiguration.AuthApiBase + "/api/Authentication/verify?role=" + role,
                AccessToken = token
            });
            return response;
        }
    }
}
