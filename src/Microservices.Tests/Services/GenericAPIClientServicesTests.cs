using Microservices.BusinessLogic.APIClient.Implmentations;
using Microservices.Common.CustomExceptions;
using Microservices.Models;
using Microservices.Tests.MockData;
using Microservices.Tests.TestData;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Serilog;
using System.Net;

namespace Microservices.Tests.Services
{
    public class GenericAPIClientServicesTests
    {
        private readonly HttpClient _httpClientMock;
        private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private readonly Mock<ILogger> _loggerMock;
        private readonly GenericAPIClientServices _service;
        string dummyBaseURL = UrlMock.GetBaseUrlFaker();
        string dummyApiKey = UrlMock.GetApiKeyFaker();
        string dummyData = UrlMock.GetDataFaker();

        public GenericAPIClientServicesTests()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
           _httpClientMock = new HttpClient(_httpMessageHandlerMock!.Object);
            _loggerMock = new Mock<ILogger>();
            _service = new GenericAPIClientServices
            (
                _httpClientMock,
                _loggerMock.Object
            );

        }

       [Fact]
       public async Task GetAsync_ReturnsValidResponse_WhenValidParameters()
       {
            EmailVerificationRequest expected = EmailVerificationRequestFaker.GetFaker();
            string json = JsonConvert.SerializeObject(expected);
            string dummyBaseURL = UrlMock.GetBaseUrlFaker();
            string dummyApiKey = UrlMock.GetApiKeyFaker();
            string dummyData = UrlMock.GetDataFaker();
            string dummyURL = $"{dummyBaseURL}/{dummyApiKey}/{Uri.EscapeDataString(dummyData)}";

            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(json),
                });

            // Act
            EmailVerificationRequest result = await _service.GetAsync<EmailVerificationRequest>(dummyData, dummyBaseURL, dummyApiKey);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected.Email, result.Email);
            _loggerMock.Verify(l =>
                l.Information("Starting API call to {Url}", dummyURL),
                Times.Once);
            _loggerMock.Verify(l => l.Information("Successfully fetched response from API."), Times.Once);

        }

        [Theory]
        [InlineData(null, "apikey")]
        [InlineData("baseUrl", null)]
        public async Task GetAsync_ThrowsArgumentException_WhenMissingBaseUrlOrApiKey(string? baseUrl, string? apiKey)
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() =>
                _service.GetAsync<EmailVerificationRequest>("data", baseUrl!, apiKey!));
            _loggerMock.Verify(l => l.Error("baseUrl and apiKey are required but were not provided"), Times.Once);
        }

        [Fact]
        public async Task GetAsync_ThrowsThirdPartyAPIException_WhenNetworkError()
        {
            string dummyBaseURL = UrlMock.GetBaseUrlFaker();
            string dummyApiKey = UrlMock.GetApiKeyFaker();
            string dummyData = UrlMock.GetDataFaker();
            string dummyURL = $"{dummyBaseURL}/{dummyApiKey}/{Uri.EscapeDataString(dummyData)}";

            // Arrange
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ThrowsAsync(new HttpRequestException("Network fail"));

            // Act & Assert
            ThirdPartyAPIException ex = await Assert.ThrowsAsync<ThirdPartyAPIException>(() =>
                _service.GetAsync<EmailVerificationRequest>(dummyData, dummyBaseURL, dummyApiKey));

            _loggerMock.Verify(l => l.Information("Starting API call to {Url}", dummyURL),Times.Once);
            _loggerMock.Verify(l =>
             l.Error(
                 It.Is<Exception>(ex =>
                     ex is HttpRequestException
                 ),
                 "A network error occurred while making a GET request to {Url}",
                 dummyURL
             ),
             Times.Once);
        }

        [Fact]
        public async Task GetAsync_ThrowsThirdPartyAPIException_WhenJsonDeserilizeError()
        {
            string dummyBaseURL = UrlMock.GetBaseUrlFaker();
            string dummyApiKey = UrlMock.GetApiKeyFaker();
            string dummyData = UrlMock.GetDataFaker();
            string dummyURL = $"{dummyBaseURL}/{dummyApiKey}/{Uri.EscapeDataString(dummyData)}";

            // Arrange
            string invalidJson = UrlMock.GetDataFaker(); ;
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(invalidJson),
                });

            // Act & Assert
            ThirdPartyAPIException ex = await Assert.ThrowsAsync<ThirdPartyAPIException>(() =>
                _service.GetAsync<EmailVerificationRequest>(dummyData, dummyBaseURL, dummyApiKey));

            _loggerMock.Verify(l => l.Information("Starting API call to {Url}", dummyURL), Times.Once);
            _loggerMock.Verify(l =>
             l.Error(
                 It.Is<Exception>(ex =>
                     ex is JsonException
                 ),
                 "Failed to deserialize the response from {Url}",
                 dummyURL
             ),
             Times.Once);
        }

        [Fact]
        public async Task GetAsync_ThrowsThirdPartyAPIException_WhenRequestTimedOut()
        {
            string dummyBaseURL = UrlMock.GetBaseUrlFaker();
            string dummyApiKey = UrlMock.GetApiKeyFaker();
            string dummyData = UrlMock.GetDataFaker();
            string dummyURL = $"{dummyBaseURL}/{dummyApiKey}/{Uri.EscapeDataString(dummyData)}";

            // Arrange: Simulate unexpected exception in SendAsync
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ThrowsAsync(new TaskCanceledException("Request timed out!"));

            // Act & Assert
            ThirdPartyAPIException ex = await Assert.ThrowsAsync<ThirdPartyAPIException>(() =>
                _service.GetAsync<EmailVerificationRequest>(dummyData, dummyBaseURL, dummyApiKey));

            _loggerMock.Verify(l => l.Information("Starting API call to {Url}", dummyURL), Times.Once);
            _loggerMock.Verify(l =>
             l.Error(
                It.Is<Exception>(ex =>
                     ex is TaskCanceledException
                 ),
                 "The request to {Url} timed out.",
                 dummyURL
             ),
             Times.Once);
        }

        [Fact]
        public async Task GetAsync_ThrowsThirdPartyAPIException_WhenUnexpectedError()
        {
            string dummyBaseURL = UrlMock.GetBaseUrlFaker();
            string dummyApiKey = UrlMock.GetApiKeyFaker();
            string dummyData = UrlMock.GetDataFaker();
            string dummyURL = $"{dummyBaseURL}/{dummyApiKey}/{Uri.EscapeDataString(dummyData)}";

            // Arrange: Simulate unexpected exception in SendAsync
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ThrowsAsync(new Exception("Something went wrong!"));

            // Act & Assert
            ThirdPartyAPIException ex = await Assert.ThrowsAsync<ThirdPartyAPIException>(() =>
                _service.GetAsync<EmailVerificationRequest>(dummyData, dummyBaseURL, dummyApiKey));

            _loggerMock.Verify(l => l.Information("Starting API call to {Url}", dummyURL), Times.Once);
            _loggerMock.Verify(l =>
             l.Error(
                 It.IsAny<Exception>(),
                 "An unexpected error occurred while making a GET request to {Url}",
                 dummyURL
             ),
             Times.Once);
        }

    }
}
