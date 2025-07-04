using AutoMapper;
using Microservices.BusinessLogic.APIClient.Interfaces;
using Microservices.BusinessLogic.Implmentations;
using Microservices.Models.DTO;
using Microservices.Models;
using Microsoft.Extensions.Configuration;
using Moq;
using Serilog;
using static Microservices.Tests.MockData.ProxyAndVpnDetectionMock;

namespace Microservices.Tests.Services
{
    public class ProxyAndVpnDetectionTests
    {
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly Mock<IGenericAPIClientServices> _apiClientMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ILogger> _loggerMock;
        private readonly ProxyAndVpnDetectionServices _service;

        public ProxyAndVpnDetectionTests()
        {
            _configurationMock = new Mock<IConfiguration>();
            _apiClientMock = new Mock<IGenericAPIClientServices>();
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger>();

            _configurationMock.Setup(c => c["IPQS:ApiKey"]).Returns("fake-api-key");
            _configurationMock.Setup(c => c["IPQS:ProxyAndVpnDetectionBaseUrl"]).Returns("https://fake-base-url.com");

            _service = new ProxyAndVpnDetectionServices(
                _configurationMock.Object,
                _apiClientMock.Object,
                _mapperMock.Object,
                _loggerMock.Object
            );
        }

        [Fact]
        public async Task ProxyAndVpnDetectionAsync_ReturnsSuccessResponse_WhenValidIpAddress()
        {
            // Arrange
            ProxyAndVpnDetectionRequest request = ProxyAndVpnDetectionFaker.GetRequestFaker();
            ProxyAndVpnDetectionResponseDTO resultDto = new();
            ProxyAndVpnDetectionResponse result = ProxyAndVpnDetectionFaker.GetResponseFaker();

            _apiClientMock
                .Setup(a => a.GetAsync<ProxyAndVpnDetectionResponseDTO>(
                    request.IpAddress, "https://fake-base-url.com", "fake-api-key"))
                .ReturnsAsync(resultDto);

            _mapperMock
                .Setup(m => m.Map<ProxyAndVpnDetectionResponse>(resultDto))
                .Returns(result);

            // Act
            ProxyAndVpnDetectionResponse response = await _service.ProxyAndVpnDetectionAsync(request);

            // Assert
            Assert.NotNull(request);
            Assert.NotNull(request.IpAddress);
            Assert.Equal(result, response);
            _loggerMock.Verify(l => l.Information("Calling generic api client service for ProxyAndVpnDetectionAsync service"), Times.Once);
            _loggerMock.Verify(l => l.Information("Successfully fetched response from client service."), Times.Once);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async Task ProxyAndVpnDetectionAsync_ReturnsError_WhenIpAddressNullOrEmpty(string data)
        {
            // Arrange
            ProxyAndVpnDetectionRequest request = new (){ IpAddress = data};
            ProxyAndVpnDetectionResponse result = ProxyAndVpnDetectionFaker.GetResponseFaker();

            // Act
            ArgumentException ex = await Assert.ThrowsAsync<ArgumentException>(() =>
                _service.ProxyAndVpnDetectionAsync(request)
            );

            // Assert
            Assert.Equal("ipaddress is null or empty!",ex.Message);
        }
    }
}
