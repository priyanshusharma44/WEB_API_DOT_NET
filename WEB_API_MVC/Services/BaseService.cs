using WEB_API_MVC.Models;
using WEB_API_MVC.Services.IServices;

namespace WEB_API_MVC.Services
{
    public class BaseService : IBaseService
    {
        public APIResponse responseModel { get; set; }
        public IHttpClientFactory httpClient { get; set; }
        public BaseService() { 
        this.responseModel = new APIResponse();
        this.httpClient = httpClient;
        }
        public Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("MagicAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
            }
        }
    }
}
