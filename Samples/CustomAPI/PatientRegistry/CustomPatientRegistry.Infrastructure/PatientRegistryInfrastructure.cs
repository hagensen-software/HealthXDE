using HealthXDE.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace CustomPatientRegistry.Infrastructure;

public class PatientRegistryInfrastructure : IInfrastructure
{
    public void RegisterServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<PatientRepository>();
    }
}
