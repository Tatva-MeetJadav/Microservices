using Microservices.BusinessLogic.APIClient.Interfaces;
using Newtonsoft.Json;

namespace Microservices.BusinessLogic.APIClient.Implmentations
{
    public class GenericAPIClientService:IGenericAPIClientServices
    {
        private readonly HttpClient _httpClient;

        public GenericAPIClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
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
                throw new ArgumentException("baseUrl and apiKey is required.");
            }

            HttpResponseMessage httpResponse = await _httpClient.GetAsync(url);
            httpResponse.EnsureSuccessStatusCode();
            string json = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json) ?? Activator.CreateInstance<T>();
        }
    }
}
