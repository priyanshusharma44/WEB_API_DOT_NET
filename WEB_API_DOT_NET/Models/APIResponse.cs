using System.Net;

namespace WEB_API_DOT_NET.Models
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> ErrorsMessage { get; set; }

        public object Result {  get; set; }
    }
}
