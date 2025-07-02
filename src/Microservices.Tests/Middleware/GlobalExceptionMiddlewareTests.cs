using Microservices.Common.ErrorHandlers;
using Microservices.Models;
using Microsoft.AspNetCore.Http;
using Moq;
using Serilog;
using System.Net;
using System.Text.Json;

namespace Microservices.Tests.Middleware
{
    public class GlobalExceptionMiddlewareTests
    {
        private readonly Mock<ILogger> _loggerMock;
        public GlobalExceptionMiddlewareTests() 
        {
            _loggerMock = new Mock<ILogger>();
        }
        [Fact]
        public async Task InvokeAsync_Returns500StatusCodeAndLogsError_WhenApplicationThrowsAnyException()
        {
            // Arrange
            DefaultHttpContext context = new ();
            MemoryStream responseBody = new ();
            context.Response.Body = responseBody;
            RequestDelegate next = (ctx) => throw new Exception("Gobal exception test error");
            GlobalExceptionMiddleware middleware = new (next, _loggerMock.Object);

            // Act
            await middleware.InvokeAsync(context);

            // Assert
            Assert.Equal((int)HttpStatusCode.InternalServerError, context.Response.StatusCode);
            Assert.Equal("application/json", context.Response.ContentType);


            //Testing the content of response body of context
            responseBody.Seek(0, SeekOrigin.Begin);
            string bodyText = await new StreamReader(responseBody).ReadToEndAsync();

            APIResponse? apiResponse = JsonSerializer.Deserialize<APIResponse>(bodyText);
            Assert.NotNull(apiResponse);
            Assert.False(apiResponse.Success);
            Assert.Equal("Gobal exception test error", apiResponse.Message);

            _loggerMock.Verify(l => l.Error("Unexpected error caught by global middleware."), Times.Once);
        }
    }
}
