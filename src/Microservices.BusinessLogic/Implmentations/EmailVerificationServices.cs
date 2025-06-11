using AutoMapper;
using Microservices.BusinessLogic.APIClient.Interfaces;
using Microservices.BusinessLogic.DTO;
using Microservices.BusinessLogic.Interfaces;
using Microservices.Models;
using Microsoft.Extensions.Configuration;

namespace Microservices.BusinessLogic.Implmentations
{
    public class EmailVerificationServices : IEmailVerificationServices
    {
        private readonly string _apiKey;
        private readonly string _baseUrl;
        private readonly IGenericAPIClientServices _apiClient;
        private readonly IMapper _mapper;

        public EmailVerificationServices(IConfiguration configuration, IGenericAPIClientServices apiClient, IMapper mapper)
        {
            _apiKey = configuration["IPQS:ApiKey"] ?? string.Empty;
            _baseUrl = configuration["IPQS:BaseUrl"] ?? string.Empty;
            _apiClient = apiClient;
            _mapper = mapper;
        }
        public async Task<EmailVerificationAPIResponse> VerifyEmailAsync(EmailVerificationRequest request)
        {
            string data = request.Email;
            if (request == null || string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("Email is required.");
            }

            EmailVerificationResponseDTO resultDTO = await _apiClient.GetAsync<EmailVerificationResponseDTO>(data, _baseUrl, _apiKey);
            EmailVerificationResponse result = _mapper.Map<EmailVerificationResponse>(resultDTO);
            return new EmailVerificationAPIResponse
            {
                Result = result,
                ApiResponse = new APIResponse
                {
                    Success = true,
                    Message = "Operation successfull.",
                    Errors = null
                }
            };
        }
    }
}