using AutoMapper;
using Microservices.BusinessLogic.DTO;
using Microservices.Models;

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