using FluentValidation;
using Microservices.Models;
using System.Net;
using System.Text.RegularExpressions;

namespace Microservices.Common.Validations
{
    public class ProxyAndVpnDetectionRequestValidator : AbstractValidator<ProxyAndVpnDetectionRequest>
    {
        public ProxyAndVpnDetectionRequestValidator()
        {
            RuleFor(x => x.IpAddress)
           .NotEmpty().WithMessage("IP Address is required.")
           .Must(ip =>
               !string.IsNullOrWhiteSpace(ip) &&
               Regex.IsMatch(ip, @"^(\d{1,3}\.){3}\d{1,3}$") &&
               IPAddress.TryParse(ip, out _)
           )
           .WithMessage("Invalid IP Address format.");
        }
    }
}
