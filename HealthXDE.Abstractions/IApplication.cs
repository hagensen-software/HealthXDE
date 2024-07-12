namespace HealthXDE.Abstractions;

public interface IApplication
{
    IApplication RegisterRequests(string route, IRequestConfiguration configuration);
}
