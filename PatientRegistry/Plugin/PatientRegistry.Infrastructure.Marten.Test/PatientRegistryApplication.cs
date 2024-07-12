using HealthXDE.Abstractions;

namespace PatientRegistry.Infrastructure.Marten.Test
{
    internal class PatientRegistryApplication : IApplication
    {
        public IApplication RegisterRequests(string route, IRequestConfiguration configuration)
        {
            return this;
        }
    }
}