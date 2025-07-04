using Microservices.Models;

namespace Microservices.BusinessLogic.Interfaces
{
    public interface IProxyAndVpnDetectionServices
    {
        Task<ProxyAndVpnDetectionResponse> ProxyAndVpnDetectionAsync(ProxyAndVpnDetectionRequest request);
    }
}
