using Newtonsoft.Json;
using StudentHelper.API.Models;
using StudentHelper.API.Services.IServices;
using System.Text;

namespace StudentHelper.API.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto responseModel { get; set; }
        private readonly IHttpClientFactory _httpClient;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            responseModel = new ResponseDto();
            _httpClient = httpClientFactory;
        }



        public T Send<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = _httpClient.CreateClient("StudentHelperAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);

                client.DefaultRequestHeaders.Clear();

                if (apiRequest.Data != null)
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, "application/json");
                if (!string.IsNullOrEmpty(apiRequest.AccessToken))
                    message.Headers.Add("Authorization", "Bearer " + apiRequest.AccessToken);
                HttpResponseMessage apiResponse = null;

                switch (apiRequest.ApiType)
                {
                    case Configuration.ApiConfiguration.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;

                    case Configuration.ApiConfiguration.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;

                    case Configuration.ApiConfiguration.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;

                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                apiResponse = client.Send(message);
                if (apiResponse.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception("Unauthorized");
                var apiContent = apiResponse.Content.ReadAsStringAsync().Result;
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);
                return apiResponseDto;
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto
                {
                    DisplayMessage = "Error",
                    ErrorMessages = new List<string> { ex.Message.ToString() },
                    IsSuccess = false
                };

                var res = JsonConvert.SerializeObject(dto);

                return JsonConvert.DeserializeObject<T>(res);

            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
