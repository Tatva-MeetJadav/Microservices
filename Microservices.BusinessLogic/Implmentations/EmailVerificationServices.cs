using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microservices.BusinessLogic.Dto;
using Microservices.BusinessLogic.Interfaces;
using Microservices.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace Microservices.BusinessLogic
{
    public class EmailVerificationServices : IEmailVerificationServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public EmailVerificationServices(IConfiguration configuration, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiKey = configuration["IPQS:ApiKey"] ?? string.Empty;
            _baseUrl = configuration["IPQS:BaseUrl"] ?? string.Empty;
        }
        public async Task<EmailVerificationAPIResponse> VerifyEmailAsync(EmailVerificationRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Email))
            {
                throw new ArgumentException("Email is required.");
            }

            var baseUrl = _baseUrl;
            var url = $"{baseUrl}/{_apiKey}/{request.Email}";
            var httpResponse = await _httpClient.GetAsync(url);
            httpResponse.EnsureSuccessStatusCode();
            var jsonResult = await httpResponse.Content.ReadAsStringAsync();
            EmailVerificationAPIResponse result = new();

            if (!string.IsNullOrEmpty(jsonResult))
            {
                var settings = new JsonSerializerSettings
                {
                    ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver
                    {
                        NamingStrategy = new Newtonsoft.Json.Serialization.SnakeCaseNamingStrategy()
                    }
                };
                EmailVerificationDto deserilizedResult = JsonConvert.DeserializeObject<EmailVerificationDto>(
                  jsonResult, settings
                  )
                  ?? new EmailVerificationDto();
                // result = new EmailVerificationAPIResponse
                // {
                //     ApiResponse = new APIResponse
                //     {
                //         Success = true,
                //         Errors = null,
                //         Message = "Email verification process completed."
                //     },
                //     Result = deserilizedResult
                // };
            }
            return result;
        }
    }
}