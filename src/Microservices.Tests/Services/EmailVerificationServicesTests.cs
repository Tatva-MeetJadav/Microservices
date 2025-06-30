using AutoMapper;
using Microservices.BusinessLogic.APIClient.Interfaces;
using Microservices.BusinessLogic.Implmentations;
using Microservices.Models;
using Microservices.Models.DTO;
using Microservices.Tests.TestData;
using Microsoft.Extensions.Configuration;
using Moq;
using Serilog;

namespace Microservices.Tests.BusinessLogic.Implmentations
{
    public class EmailVerificationServicesTests
    {
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly Mock<IGenericAPIClientServices> _apiClientMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ILogger> _loggerMock;
        private readonly EmailVerificationServices _service;

        public EmailVerificationServicesTests()
        {
            _configurationMock = new Mock<IConfiguration>();
            _apiClientMock = new Mock<IGenericAPIClientServices>();
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger>();

            _configurationMock.Setup(c => c["IPQS:ApiKey"]).Returns("fake-api-key");
            _configurationMock.Setup(c => c["IPQS:BaseUrl"]).Returns("https://fake-base-url.com");

            _service = new EmailVerificationServices(
                _configurationMock.Object,
                _apiClientMock.Object,
                _mapperMock.Object,
                _loggerMock.Object
            );
        }

        [Fact]
        public async Task VerifyEmailAsync_WithValidEmail_ReturnsSuccessResponse()
        {
            // Arrange
            EmailVerificationRequest request = EmailVerificationFakers.EmailRequestFaker.Generate();
            EmailVerificationResponseDTO resultDto = EmailVerificationFakers.EmailResponseDtoFaker.Generate();
            EmailVerificationResponse result = new ();

            _apiClientMock
                .Setup(a => a.GetAsync<EmailVerificationResponseDTO>(
                    request.Email, "https://fake-base-url.com", "fake-api-key"))
                .ReturnsAsync(resultDto);

            _mapperMock
                .Setup(m => m.Map<EmailVerificationResponse>(resultDto))
                .Returns(result);

            // Act
            EmailVerificationAPIResponse response = await _service.VerifyEmailAsync(request);

            // Assert
            Assert.True(response.ApiResponse.Success);
            Assert.Equal("Operation successfull.", response.ApiResponse.Message);
            Assert.Null(response.ApiResponse.Errors);
            Assert.Equal(result, response.Result);
            _loggerMock.Verify(l => l.Information("Calling api client service for email verification"), Times.Once);
            _loggerMock.Verify(l => l.Information("Successfully fetched response from client service."), Times.Once);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async Task VerifyEmailAsync_WithNullOrEmptyEmail_ReturnsErrorResponse(string email)
        {
            // Arrange
            EmailVerificationRequest request = new () { Email = email };

            // Act
            EmailVerificationAPIResponse response = await _service.VerifyEmailAsync(request);

            // Assert
            Assert.False(response.ApiResponse.Success);
            Assert.Equal("Email should not be empty", response.ApiResponse.Message);
            Assert.NotNull(response.ApiResponse.Errors);
            Assert.Contains("Email is empty here, please check again", response.ApiResponse.Errors);
            _loggerMock.Verify(l => l.Error("Email is null or empty found!"), Times.Once);
        }
    }
}