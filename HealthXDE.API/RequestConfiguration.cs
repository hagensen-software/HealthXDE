using HealthXDE.Abstractions;
using Microsoft.AspNetCore.Builder;

namespace HealthXDE.API;

internal class RequestConfiguration : IRequestConfiguration
{
    private readonly WebApplication webApplication;

    public RequestConfiguration(WebApplication webApplication)
    {
        this.webApplication = webApplication;
    }

    public IRequestConfiguration MapCommand(string name, string route, Delegate command)
    {
        webApplication.MapPost(route, command)
            .WithName(name)
            .WithOpenApi();

        return this;
    }

    public IRequestConfiguration MapQuery(string name, string route, Delegate query)
    {
        webApplication.MapGet(route, query)
            .WithName(name)
            .WithOpenApi();

        return this;
    }
}
