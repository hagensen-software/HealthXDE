using CustomPatientRegistry.Domain.Events;
using HealthXDE.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace CustomPatientRegistry.Domain;

public static class CustomPatientRegistryDomain
{
    public static IServiceCollection RegisterCustomRegistryDomain(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IDomainEventResolver<Patient>>(resolver => new PatientEventResolver());

        return serviceCollection;
    }
}
