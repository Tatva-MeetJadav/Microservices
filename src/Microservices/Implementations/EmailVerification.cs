using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microservices.BusinessLogic.Interfaces;
using Microservices.Models;
using System.Collections.Generic;

namespace Microservices.Controllers
{
    [Route("[controller]")]
    public class EmailVerificationController : DefaultApiController
    {
        private readonly IEmailVerificationServices _emailVerificationService;

        public EmailVerificationController(IEmailVerificationServices emailVerificationService)
        {
            _emailVerificationService = emailVerificationService;
        }

        public override async Task<IActionResult> EmailVerifyPost([FromBody] EmailVerificationRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Email))
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
                var result = await _emailVerificationService.VerifyEmailAsync(request);
                return Ok(result); // 200 with EmailVerificationAPIResponse
            }
            catch (Exception ex)
            {
                return StatusCode(500, new APIResponse
                {
                    Success = false,
                    Message = "An unexpected error occurred.",
                    Errors = new List<string>{ ex.Message },
                });
            }
        }
    }
}