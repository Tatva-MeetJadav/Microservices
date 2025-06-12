using Microservices.Common.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

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
                List<ErrorDetail> errors = context.ModelState
                    .Where(x => x.Value?.Errors.Count > 0)
                    .Select(x => new ErrorDetail
                    {
                        Field = x.Key,
                        ErrorMessages = x.Value?.Errors.Select(e => e.ErrorMessage).ToList()
                    }).ToList();

                Log.Warning("Model validation failed for {Path}. Errors: {@Errors}", context.HttpContext.Request.Path, errors);

                ValidationError validationError = new ValidationError
                {
                    StatusCode = 400,
                    Message = "Model Validation Failed.",
                    Errors = errors
                };

                return new BadRequestObjectResult(validationError);
            };
        });

        return services;
    }
}