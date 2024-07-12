namespace HealthXDE.API;

public class ServiceLocator(HealthXDEConfiguration configuration)
{
    public HealthXDEConfiguration Configuration { get; } = configuration;
}