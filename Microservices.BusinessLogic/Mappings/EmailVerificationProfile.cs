using AutoMapper;
using Microservices.BusinessLogic.Dto;
using Microservices.Models;

public class EmailVerificationProfile : Profile
{
    public EmailVerificationProfile()
    {
        CreateMap<EmailVerificationDTO, EmailVerificationResponse>();
        CreateMap<AssociatedNamesDTO, EmailVerificationResponseAssociatedNames>();
        CreateMap<AssociatedPhoneNumbersDTO, EmailVerificationResponseAssociatedPhoneNumbers>();
        CreateMap<TimeInfoDTO, EmailVerificationResponseFirstSeen>();
        CreateMap<TimeInfoDTO, EmailVerificationResponseDomainAge>();
    }
}