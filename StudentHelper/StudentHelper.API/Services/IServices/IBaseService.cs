using StudentHelper.API.Models;

namespace StudentHelper.API.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDto responseModel { get; set; }

        T Send<T>(ApiRequest apiRequest);
    }
}
