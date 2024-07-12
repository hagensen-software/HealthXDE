using HealthXDE.Abstractions;

namespace PatientRegistry.Application;

public class PatientRegistryApplication : IApplication
{
    public IApplication RegisterRequests(string route, IRequestConfiguration configuraton)
    {
        return this;
    }
}
