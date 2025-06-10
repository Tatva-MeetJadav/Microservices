using Microservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.BusinessLogic.Interfaces
{
    public interface IEmailVerificationServices
    {
        Task<EmailVerificationAPIResponse> VerifyEmailAsync(EmailVerificationRequest request);
    }
}
