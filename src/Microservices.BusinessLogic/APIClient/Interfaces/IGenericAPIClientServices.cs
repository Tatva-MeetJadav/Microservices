

namespace Microservices.BusinessLogic.APIClient.Interfaces
{
    public interface IGenericAPIClientServices
    {
        Task<T> GetAsync<T>(string data, string baseUrl, string apiKey);
    }
}
