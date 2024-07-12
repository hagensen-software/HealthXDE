using MediatR;
using HealthXDE.Domain.Patient;

namespace GeneralPatientRegistry.Application.RegisterPatient;

public class RegisterPatientCommand : IRequest
{
    public RegisterPatientCommand(PatientId patientId)
    {
        PatientId = patientId;
    }

    public PatientId PatientId { get; }
}
