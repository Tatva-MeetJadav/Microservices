using Microservices.Models;
namespace Microservices.BusinessLogic.Interfaces
{
    public interface IEmailVerificationServices
    {
        Task<EmailVerificationAPIResponse> VerifyEmailAsync(EmailVerificationRequest request);
    }
}
