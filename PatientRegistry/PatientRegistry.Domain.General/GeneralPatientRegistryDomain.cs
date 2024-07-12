using HealthXDE.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using PatientRegistry.Domain.General.Events;

namespace PatientRegistry.Domain.General;

public static class GeneralPatientRegistryDomain
{
    public static IServiceCollection AddGeneralPatientRegistryDomain(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IDomainEventResolver<Patient>>(resolver => new PatientEventResolver());

        return serviceCollection;
    }
}
