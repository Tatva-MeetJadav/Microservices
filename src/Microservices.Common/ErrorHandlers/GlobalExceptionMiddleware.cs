using Microservices.Common.DTO;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using Serilog;

namespace Microservices.Common.ErrorHandlers
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public GlobalExceptionMiddleware(RequestDelegate next,ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.Error("Unexpected error caught by global middleware.");
                await HandleExceptionAsync(context,ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context,Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            ErrorResponse response = new ErrorResponse
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message,
            };
           
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}