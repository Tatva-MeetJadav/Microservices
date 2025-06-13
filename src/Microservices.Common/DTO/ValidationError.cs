
namespace Microservices.Common.DTO
{
    internal class ValidationError:ErrorResponse
    {
        public List<ErrorDetail>? Errors { get; set; }
    }
    internal class ErrorDetail
    {
        public List<string>? ErrorMessages { get; set; }

        public string? Field { get; set; }
    }
}
