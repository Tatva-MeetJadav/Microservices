using System.Net;

namespace Microservices.BusinessLogic.CustomExceptions
{
    public class ThirdPartyAPIException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public string ApiErrorCode { get; }
        public string ApiErrorDetails { get; }

        public ThirdPartyAPIException(
            string message,
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
            string? apiErrorCode = null,
            string? apiErrorDetails = null)
            : base(message)
        {
            StatusCode = statusCode;
            ApiErrorCode = apiErrorCode ?? string.Empty;
            ApiErrorDetails = apiErrorDetails ?? string.Empty;
        }
    }
}