using static Villa_Utility.SD;

namespace WEB_API_MVC.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data {  get; set; }
    }
}
