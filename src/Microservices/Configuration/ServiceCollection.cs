using Microservices.BusinessLogic.APIClient.Implmentations;
using Microservices.BusinessLogic.APIClient.Interfaces;
using Microservices.BusinessLogic.Implmentations;
using Microservices.BusinessLogic.Interfaces;
using Microsoft.Extensions.DependencyInjection;


/// <summary>
///Adding services
/// </summary>
public static class ServiceCollection
{
    /// <summary>
    ///Adding BusinessLogicservices
    /// </summary>
    public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
    {
        // Register your services here
        services.AddScoped<IEmailVerificationServices, EmailVerificationServices>();
        services.AddScoped<IGenericAPIClientServices, GenericAPIClientServices>();
        return services;
    }
}