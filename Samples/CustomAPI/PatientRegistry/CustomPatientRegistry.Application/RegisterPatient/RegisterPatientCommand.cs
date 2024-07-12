using CustomPatientRegistry.Domain;
using HealthXDE.Domain.Patient;
using MediatR;

namespace CustomPatientRegistry.Application.RegisterPatient;

public class RegisterPatientCommand : IRequest
{
    public RegisterPatientCommand(PatientId patientId, OfficialName name)
    {
        PatientId = patientId;
        Name = name;
    }

    public PatientId PatientId { get; }
    public OfficialName Name { get; }
}
