using AutoMapper;
using Microservices.BusinessLogic.Dto;
using Microservices.Models;

public class EmailVerificationProfile : Profile
{
    public EmailVerificationProfile()
    {
        CreateMap<EmailVerificationDto, EmailVerificationAPIResponse>();
        // Add additional mappings as needed
    }
}