//using AspNet.Security.OAuth.Intita;

namespace ApiRequest
{
    public class ApiResponse<TResponse>
    {
        public int StatusCode { get; set; }
        public string ContentAsString { get; set; }
        public TResponse Response { get; set; }
        public bool IsDeserializeSuccess { get; set; }
    }
}