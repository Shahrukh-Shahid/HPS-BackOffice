namespace HPS_backoffice.DTOs.Common
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; } = string.Empty;
        public object Data { get; set; }

        public Response(int statusCode, string? errorMsg, object data)
        {
            StatusCode = statusCode;
            Message = errorMsg;
            Data = data;
        }
    }
}
