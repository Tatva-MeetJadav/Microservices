using Microservices.BusinessLogic.APIClient.Interfaces;
using Microservices.Common.CustomExceptions;
using Newtonsoft.Json;
using Serilog;

namespace Microservices.BusinessLogic.APIClient.Implmentations
{
   
    public class GenericAPIClientServices : IGenericAPIClientServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;

        public GenericAPIClientServices(HttpClient httpClient, ILogger logger)
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
                _logger.Error("baseUrl and apiKey are required but were not provided.");
                throw new ArgumentException("baseUrl and apiKey is required.");
            }

            _logger.Information("Starting API call to {Url}", url);
            try
            {
                HttpResponseMessage httpResponse = await _httpClient.GetAsync(url);
                string json = await httpResponse.Content.ReadAsStringAsync();
                _logger.Information("Successfully fetched response from API.");
                return JsonConvert.DeserializeObject<T>(json) ?? Activator.CreateInstance<T>();
            }
            catch (HttpRequestException ex)
            {
                _logger.Error(ex, "A network error occurred while making a GET request to {Url}", url);
                throw new ThirdPartyAPIException(ex.Message,"Network error occurred,please check your connection.",true);
            }
            catch (JsonException ex)
            {
                _logger.Error(ex, "Failed to deserialize the response from {Url}", url);
                throw new ThirdPartyAPIException(ex.Message, "An unexpected error occurred.", false);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An unexpected error occurred while making a GET request to {Url}", url);
                throw new ThirdPartyAPIException(ex.Message, "An unexpected error occurred.", false);
            }
        }
    }
}