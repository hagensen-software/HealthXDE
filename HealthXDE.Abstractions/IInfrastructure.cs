using Microsoft.Extensions.DependencyInjection;

namespace HealthXDE.Abstractions;

public interface IInfrastructure
{
    void RegisterServices(IServiceCollection serviceCollection);
}
