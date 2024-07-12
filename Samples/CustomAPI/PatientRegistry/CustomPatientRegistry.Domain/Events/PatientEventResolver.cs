using HealthXDE.Domain.Abstractions;

namespace CustomPatientRegistry.Domain.Events;

public class PatientEventResolver : IDomainEventResolver<Patient>
{
    private Patient? patient;

    public PatientEventResolver(Patient? patient = null)
    {
        this.patient = patient;
    }

    public Task<Patient> ResolveEvents(IEnumerable<IDomainEvent> events)
    {
        foreach (var ev in events)
            Apply((dynamic)ev);

        return Task.FromResult(patient ?? throw new InvalidOperationException("Failed to resolve patient"));
    }

    public Patient Apply(PatientRegistered ev)
    {
        if (patient != null)
            throw new InvalidOperationException($"PatientRegistered is only allowed as the first event on Patient");

        return new Patient(ev.PatientId, ev.Name);
    }

    public void Apply(PatientNameChanged ev)
    {
        if (patient == null)
            throw new InvalidOperationException($"PatientNameChanged is not allowed as the first event on Patient");

        patient.Name = ev.NewName;
    }

    //public Patient Apply(AddressProvided ev)
    //{
    //    return GetPatient().Address = ev.Address;
    //}
}
