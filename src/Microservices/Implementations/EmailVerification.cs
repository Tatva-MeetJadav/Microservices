using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microservices.BusinessLogic.Interfaces;
using Microservices.Models;
using Microservices.Controllers;
using Microsoft.Extensions.Logging;

namespace Microservices.Implementations
{
    /// <summary>
    /// Handles email verification requests.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class EmailVerificationController : DefaultApiController
    {
        private readonly IEmailVerificationServices _emailVerificationService;
        private readonly ILogger<EmailVerificationController> _logger;

        /// <summary>
        /// Constructor for EmailVerificationController.
        /// </summary>
        public EmailVerificationController(IEmailVerificationServices emailVerificationService, ILogger<EmailVerificationController> logger)
        {
            _emailVerificationService = emailVerificationService;
            _logger = logger;
        }

        /// <summary>
        /// Verifies the provided email address.
        /// </summary>
        /// <param name="request">The email verification request payload.</param>
        /// <returns>A response indicating the verification result.</returns>
        public override async Task<IActionResult> EmailVerifyPost([FromBody] EmailVerificationRequest request)
        {
            _logger.LogInformation("Received email verification request for: {Email}", request?.Email);
            EmailVerificationAPIResponse result = await _emailVerificationService.VerifyEmailAsync(request);
            _logger.LogInformation("Email verification succeeded for: {Email} with status: {Status}", request.Email, result.ApiResponse.Success);
            return Ok(result);
        }
    }
}