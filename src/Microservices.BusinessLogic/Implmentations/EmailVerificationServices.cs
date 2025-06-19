using AutoMapper;
using Microservices.BusinessLogic.APIClient.Interfaces;
using Microservices.BusinessLogic.Interfaces;
using Microservices.Models;
using Microservices.Models.DTO;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Microservices.BusinessLogic.Implmentations
{
    public class EmailVerificationServices : IEmailVerificationServices
    {
        private readonly string _apiKey;
        private readonly string _baseUrl;
        private readonly IGenericAPIClientServices _apiClient;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public EmailVerificationServices(IConfiguration configuration, IGenericAPIClientServices apiClient, IMapper mapper, ILogger logger)
        {
            _apiKey = configuration["IPQS:ApiKey"] ?? string.Empty;
            _baseUrl = configuration["IPQS:BaseUrl"] ?? string.Empty;
            _apiClient = apiClient;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<EmailVerificationAPIResponse> VerifyEmailAsync(EmailVerificationRequest request)
        {
            string data = request.Email;
            _logger.Information("Calling api client service for email verification");
            EmailVerificationResponseDTO resultDTO = await _apiClient.GetAsync<EmailVerificationResponseDTO>(data, _baseUrl, _apiKey);
            EmailVerificationResponse result = _mapper.Map<EmailVerificationResponse>(resultDTO);
            _logger.Information("Successfully fetched response from client service.");
            return new EmailVerificationAPIResponse
            {
                ApiResponse = new APIResponse
                {
                    Success = true,
                    Message = "Operation successfull.",
                    Errors = null
                },
                Result = result,
            };
        }
    }
}