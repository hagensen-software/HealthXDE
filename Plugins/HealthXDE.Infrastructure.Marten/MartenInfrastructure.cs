using HealthXDE.Infrastructure.Abstractions;
using Marten;
using Microsoft.Extensions.DependencyInjection;

namespace HealthXDE.Infrastructure.Marten;

public static class MartenInfrastructure
{
    public static IServiceCollection AddMartenInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddMarten(connectionString);
        services.AddScoped<IUnitOfWork, MartenUnitOfWork>();

        return services;
    }
}
