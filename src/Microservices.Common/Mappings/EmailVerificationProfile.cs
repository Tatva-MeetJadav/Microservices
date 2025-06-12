using AutoMapper;
using Microservices.BusinessLogic.DTO;
using Microservices.Models;

namespace Microservices.Common.Mappings
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
