using System.Net;

namespace BikeStore_API
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public List<string>? ErrorMessages { get; set; } = null;
        public bool IsSuccess { get; set; }
        public Object Result { get; set; }

    }
}
