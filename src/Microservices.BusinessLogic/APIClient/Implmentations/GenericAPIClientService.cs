using Microservices.BusinessLogic.APIClient.Interfaces;
using Microservices.BusinessLogic.CustomExceptions;
using Newtonsoft.Json;
using System.Net;

namespace Microservices.BusinessLogic.APIClient.Implmentations
{
   
    public class GenericAPIClientService : IGenericAPIClientServices
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

            try
            {
                HttpResponseMessage httpResponse = await _httpClient.GetAsync(url);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    string errorContent = await httpResponse.Content.ReadAsStringAsync();

                    throw new ThirdPartyAPIException(
                        message: $"request failed with status {(int)httpResponse.StatusCode}: {httpResponse.ReasonPhrase}",
                        statusCode: httpResponse.StatusCode,
                        apiErrorDetails: errorContent
                    );
                }

                string json = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json) ?? Activator.CreateInstance<T>();
            }
            catch (HttpRequestException ex)
            {
                throw new ThirdPartyAPIException(
                    message: "A network error occurred.",
                    statusCode: HttpStatusCode.ServiceUnavailable,
                    apiErrorDetails: ex.Message
                );
            }
            catch (JsonException ex)
            {
                throw new ThirdPartyAPIException(
                    message: "Failed to deserialize the response from the third-party API.",
                    statusCode: HttpStatusCode.InternalServerError,
                    apiErrorDetails: ex.Message
                );
            }
            catch (Exception ex)
            {
                throw new ThirdPartyAPIException(
                    message: "An unexpected error occurred.",
                    statusCode: HttpStatusCode.InternalServerError,
                    apiErrorDetails: ex.Message
                );
            }
        }
    }
}