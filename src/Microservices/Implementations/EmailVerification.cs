using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microservices.BusinessLogic.Interfaces;
using Microservices.Models;
using System.Collections.Generic;
using Microservices.Controllers;

namespace Microservices.Implementations
{
    /// <summary>
    /// 
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class EmailVerificationController : DefaultApiController
    {
        private readonly IEmailVerificationServices _emailVerificationService;

        /// <summary>
        /// 
        /// </summary>
        public EmailVerificationController(IEmailVerificationServices emailVerificationService)
        {
            _emailVerificationService = emailVerificationService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override async Task<IActionResult> EmailVerifyPost([FromBody] EmailVerificationRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Email))
            {
                return BadRequest(new APIResponse
                {
                    Success = false,
                    Message = "Missing or invalid email parameter.",
                    Errors = new List<string> { "Email address is required." },
                });
            }
            try
            {
                EmailVerificationAPIResponse result = await _emailVerificationService.VerifyEmailAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new APIResponse
                {
                    Success = false,
                    Message = "An unexpected error occurred.",
                    Errors = new List<string> { ex.Message },
                });
            }
        }
    }
}