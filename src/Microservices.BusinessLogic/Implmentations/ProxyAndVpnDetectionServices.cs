using AutoMapper;
using Microservices.BusinessLogic.APIClient.Interfaces;
using Microservices.BusinessLogic.Interfaces;
using Microservices.Common.CustomExceptions;
using Microservices.Models;
using Microservices.Models.DTO;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Microservices.BusinessLogic.Implmentations
{
    public class ProxyAndVpnDetectionServices : IProxyAndVpnDetectionServices
    {
        private readonly string _apiKey;
        private readonly string _baseUrl;
        private readonly IGenericAPIClientServices _apiClient;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public ProxyAndVpnDetectionServices(IConfiguration configuration, IGenericAPIClientServices apiClient, IMapper mapper, ILogger logger) 
        {
            _apiKey = configuration["IPQS:ApiKey"] ?? string.Empty;
            _baseUrl = configuration["IPQS:ProxyAndVpnDetectionBaseUrl"] ?? string.Empty;
            _apiClient = apiClient;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ProxyAndVpnDetectionResponse> ProxyAndVpnDetectionAsync(ProxyAndVpnDetectionRequest request)
        {
            if(request == null || string.IsNullOrEmpty(request.IpAddress))
            {
                throw new ArgumentException("ipaddress is null or empty!");
            }
            string data = request.IpAddress;
            _logger.Information("Calling generic api client service for ProxyAndVpnDetectionAsync service");
            ProxyAndVpnDetectionResponseDTO resultDTO = await _apiClient.GetAsync<ProxyAndVpnDetectionResponseDTO>(data, _baseUrl, _apiKey);
            ProxyAndVpnDetectionResponse result = _mapper.Map<ProxyAndVpnDetectionResponse>(resultDTO);
            _logger.Information("Successfully fetched response from client service.");
            return result;
        }
    }
}
