namespace HealthXDE.Abstractions;

public interface IRequestConfiguration
{
    IRequestConfiguration MapCommand(string name, string route, Delegate command);
    IRequestConfiguration MapQuery(string name, string route, Delegate query);

}