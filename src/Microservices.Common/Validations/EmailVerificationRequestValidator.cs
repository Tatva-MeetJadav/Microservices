using FluentValidation;
using Microservices.Models;
namespace Microservices.Common.Validations
{
    public class EmailVerificationRequestValidator: AbstractValidator<EmailVerificationRequest>
    {
        public EmailVerificationRequestValidator()
        {
            RuleFor(x => x.Email)
               .NotEmpty().WithMessage("Email is required.")
               .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
               .WithMessage("Invalid Email Address");
        }
    }
}
