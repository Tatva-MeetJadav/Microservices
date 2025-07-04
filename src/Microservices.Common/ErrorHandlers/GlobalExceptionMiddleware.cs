using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using Serilog;
using Microservices.Models;

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

        private static Task HandleExceptionAsync(HttpContext context,Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            Error error = new()
            {
                ErrorCode = (int)HttpStatusCode.InternalServerError,
                ErrorMessage = ex.Message,
            };
           
            return context.Response.WriteAsync(JsonSerializer.Serialize(error));
        }
    }
}