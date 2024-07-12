using HealthXDE.Domain.Abstractions;
using HealthXDE.Domain.Gender;

namespace PatientRegistry.Domain.General.Events;

internal class PatientEventResolver(Patient? patient = null)
    : IDomainEventResolver<Patient>
{
    public Task<Patient> ResolveEvents(IEnumerable<IDomainEvent> events)
    {
        foreach (var ev in events)
            Apply((dynamic)ev);

        return Task.FromResult(patient ?? throw new InvalidOperationException("Failed to resolve patient"));
    }

    internal Patient Apply(PatientRegistered patientRegistered)
    {
        if (patient != null)
            throw new InvalidOperationException($"PatientRegistered is only allowed as the first event on Patient");
        return patient = new Patient(patientRegistered.PatientId);
    }

    internal Patient Apply<HumanNameType>(PatientNameAdded<HumanNameType> patientNameAdded) where HumanNameType : HumanName
    {
        if (patient == null)
            throw new InvalidOperationException($"PatientNameAdded is not allowed as the first event on Patient");

        patient.GetState().HumanNameElements.AddElement(patientNameAdded.Name);
       
        return patient;
    }

    internal Patient Apply(PatientGenderChanged patientGenderChanged)
    {
        if (patient == null)
            throw new InvalidOperationException($"PatientNameAdded is not allowed as the first event on Patient");

        patient.GetState().GenderElement.Set((AdministrativeGenderCode?)patientGenderChanged.Gender);

        return patient;
    }
}
