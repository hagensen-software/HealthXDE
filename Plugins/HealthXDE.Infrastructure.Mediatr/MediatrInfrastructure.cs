using HealthXDE.API;
using HealthXDE.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace HealthXDE.Infrastructure.Mediatr;

public static class MediatrInfrastructure
{
    public static IServiceCollection AddMediatrInfrastructure(this IServiceCollection services)
    {
        var serviceLocatorDescription = services.Where(d => d.ServiceType == typeof(ServiceLocator)).First();
        var serviceLocator = (ServiceLocator)serviceLocatorDescription.ImplementationInstance!;
        var applications = serviceLocator.Configuration.Applications;

        services.AddMediatR(cfg =>
        {
            foreach (var application in applications)
                cfg.RegisterServicesFromAssembly(application.GetType().Assembly);
        });

        services.AddScoped<IDomainEventPublisher, MediatrDomainEventPublisher>();

        return services;
    }
}
