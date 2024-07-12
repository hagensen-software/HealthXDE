using HealthXDE.Abstractions;

namespace HealthXDE.API;

public class HealthXDEConfiguration
{
    public List<(string, IApplication)> Applications { get; } = [];
    internal List<IInfrastructure> Infrastructures { get; } = [];

    public HealthXDEConfiguration RegisterApplication(string route, IApplication application)
    {
        Applications.Add((route, application));

        return this;
    }

    public HealthXDEConfiguration RegisterInfrastructure(IInfrastructure infrastructure)
    {
        Infrastructures.Add(infrastructure);

        return this;
    }
}