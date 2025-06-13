using Microservices.Common.DTO;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Microservices.Common.ErrorHandlers
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
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