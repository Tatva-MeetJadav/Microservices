using Microservices.BusinessLogic.APIClient.Interfaces;
using Microservices.Common.CustomExceptions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Microservices.BusinessLogic.APIClient.Implmentations
{
   
    public class GenericAPIClientServices : IGenericAPIClientServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<GenericAPIClientServices> _logger;

        public GenericAPIClientServices(HttpClient httpClient, ILogger<GenericAPIClientServices> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<T> GetAsync<T>(string data, string baseUrl, string apiKey)
        {
            string url;
            if (baseUrl != null && apiKey != null)
            {
                url = $"{baseUrl}/{apiKey}/{Uri.EscapeDataString(data)}";
            }
            else
            {
                _logger.LogError("baseUrl and apiKey are required but were not provided.");
                throw new ArgumentException("baseUrl and apiKey is required.");
            }

            _logger.LogInformation("Starting API call to {Url}", url);
            try
            {
                HttpResponseMessage httpResponse = await _httpClient.GetAsync(url);
                string json = await httpResponse.Content.ReadAsStringAsync();
                _logger.LogInformation("Successfully fetched response from API.");
                return JsonConvert.DeserializeObject<T>("arr") ?? Activator.CreateInstance<T>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "A network error occurred while making a GET request to {Url}", url);
                throw new ThirdPartyAPIException(ex.Message,true);
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Failed to deserialize the response from {Url}", url);
                throw new ThirdPartyAPIException(ex.Message, false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while making a GET request to {Url}", url);
                throw new ThirdPartyAPIException(ex.Message, false);
            }
        }
    }
}