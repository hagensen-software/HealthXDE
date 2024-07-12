using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HealthXDE.API;

public static class HealthXDEAPI
{
    public static IServiceCollection AddHealthXDE(this IServiceCollection serviceCollection, Action<HealthXDEConfiguration> config)
    {
        var configuration = new HealthXDEConfiguration();
        config(configuration);

        foreach (var infrastructure in configuration.Infrastructures)
            infrastructure.RegisterServices(serviceCollection);

        return serviceCollection.AddSingleton<ServiceLocator>(new ServiceLocator(configuration));
    }

    public static void UseHealthXDE(this WebApplication webApplication)
    {
        var locator = webApplication.Services.GetRequiredService<ServiceLocator>();

        foreach ((var route, var application) in locator.Configuration.Applications)
        {
            var requestConfiguration = new RequestConfiguration(webApplication);

            application.RegisterRequests(route, requestConfiguration);
        }
    }
}
