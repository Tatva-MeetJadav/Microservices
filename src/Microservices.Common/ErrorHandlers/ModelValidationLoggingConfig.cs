using Microservices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Net;

public static class ModelValidationLoggingConfig
{
    /// <summary>
    /// Extension method to configure logging of model validation errors using Serilog.
    /// Call this in ConfigureServices: services.AddModelValidationLogging();
    /// </summary>
    /// <param name="services"></param>
    public static IServiceCollection AddModelValidationLogging(this IServiceCollection services)
    {
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                List<string> errors = context.ModelState
                 .Where(x => x.Value?.Errors.Count > 0)
                 .SelectMany(x => x.Value?.Errors.Select(e => e.ErrorMessage) ?? Enumerable.Empty<string>())
                 .ToList();
                Log.Warning("Model validation failed for {Path}. Errors: {@Errors}", context.HttpContext.Request.Path, errors);

                Error error = new()
                {
                    ErrorCode = (int)HttpStatusCode.BadRequest,
                    ErrorMessage = "Bad request, your request is not valid.",
                };

                return new BadRequestObjectResult(error);
            };
        });

        return services;
    }
}