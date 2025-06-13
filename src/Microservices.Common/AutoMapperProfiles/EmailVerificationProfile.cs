using AutoMapper;
using Microservices.Models.DTO;
using Microservices.Models;

namespace Microservices.Common.AutoMapperProfiles
{
    public class EmailVerificationProfile : Profile
    {
        public EmailVerificationProfile()
        {
            CreateMap<EmailVerificationResponseDTO, EmailVerificationResponse>();
            CreateMap<AssociatedNamesDTO, EmailVerificationResponseAssociatedNames>();
            CreateMap<AssociatedPhoneNumbersDTO, EmailVerificationResponseAssociatedPhoneNumbers>();
            CreateMap<TimeInfoDTO, EmailVerificationResponseFirstSeen>();
            CreateMap<TimeInfoDTO, EmailVerificationResponseDomainAge>();
        }
    }
}
