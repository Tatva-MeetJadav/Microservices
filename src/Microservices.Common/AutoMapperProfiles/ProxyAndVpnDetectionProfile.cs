using AutoMapper;
using Microservices.Models;
using Microservices.Models.DTO;

namespace Microservices.Common.AutoMapperProfiles
{
    public class ProxyAndVpnDetectionProfile:Profile
    {
        public ProxyAndVpnDetectionProfile()
        {
            CreateMap<ProxyAndVpnDetectionResponseDTO, ProxyAndVpnDetectionResponse>();
        }
    }
}
