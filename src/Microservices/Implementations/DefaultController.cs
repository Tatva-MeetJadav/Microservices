using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microservices.BusinessLogic.Interfaces;
using Microservices.Models;
using Microservices.Controllers;
using Serilog;

namespace Microservices.Implementations
{
    /// <summary>
    /// Handles email verification requests.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class DefaultController : DefaultApiController
    {
        private readonly IEmailVerificationServices _emailVerificationService;
        private readonly IProxyAndVpnDetectionServices _proxyAndVpnDetectionService;
        private readonly ILogger _logger;

        /// <summary>
        /// Constructor for EmailVerificationController.
        /// </summary>
        public DefaultController(IEmailVerificationServices emailVerificationService, ILogger logger,IProxyAndVpnDetectionServices proxyAndVpnDetectionService)
        {
            _emailVerificationService = emailVerificationService;
            _proxyAndVpnDetectionService = proxyAndVpnDetectionService;
            _logger = logger;
        }

        /// <summary>
        /// Verifies the provided email address.
        /// </summary>
        /// <param name="request">The email verification request payload.</param>
        /// <returns>A response indicating the verification result.</returns>
        public override async Task<IActionResult> EmailVerifyPost([FromBody] EmailVerificationRequest request)
        {
            _logger.Information("Received email verification request for: {Email}", request?.Email);
            EmailVerificationAPIResponse result = await _emailVerificationService.VerifyEmailAsync(request);
            _logger.Information("Email verification succeeded for: {Email} with status: {Status}", request.Email, result.ApiResponse.Success);
            return Ok(result);
        }

        public override Task<IActionResult> PhoneValidatePost([FromBody] PhoneValidationRequest phoneValidationRequest)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Verifies the provided email address.
        /// </summary>
        /// <param name="proxyAndVpnDetectionRequest">The ProxyAndVpnDetection request payload.</param>
        /// <returns>A response indicating the verification result.</returns>
        public override async Task<IActionResult> ProxyAndVpnDetectionPost([FromBody] ProxyAndVpnDetectionRequest proxyAndVpnDetectionRequest)
        {
            _logger.Information("Received ProxyAndVpnDetection request for: {IpAddress}", proxyAndVpnDetectionRequest.IpAddress);
            ProxyAndVpnDetectionResponse result = await _proxyAndVpnDetectionService.ProxyAndVpnDetectionAsync(proxyAndVpnDetectionRequest);
            _logger.Information("ProxyAndVpnDetection succeeded for: {IpAddress}", proxyAndVpnDetectionRequest.IpAddress);
            return Ok(result);
        }
    }
}