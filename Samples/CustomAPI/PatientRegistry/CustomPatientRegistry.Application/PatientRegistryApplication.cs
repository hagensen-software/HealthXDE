using HealthXDE.Abstractions;
using MediatR;

namespace CustomPatientRegistry.Application;

public class PatientRegistryApplication : IApplication
{
    public IApplication RegisterRequests(string route, IRequestConfiguration configuration)
    {
        //configuration
        //    .MapCommand("RegisterPatient",
        //                $"{route}/register",
        //                async (RegisterPatientCommand command, IMediator mediator) => await mediator.Send(command));

        return this;
    }
}
