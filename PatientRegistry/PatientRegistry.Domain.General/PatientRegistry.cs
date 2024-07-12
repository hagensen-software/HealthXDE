using HealthXDE.Domain.Patient;

namespace PatientRegistry.Domain.General;

public interface IPatientRepository
{
    public void Add(Patient patient);
}

public interface IPatient { }

public class PatientRegistry // Aggregate Root
{
    private readonly IPatientRepository patientRepository;

    public PatientRegistry(IPatientRepository patientRepository)
    {
        this.patientRepository = patientRepository;
    }

    public void RegisterNewPatient(IPatient newPatient)
    {
        var patientId = new PatientId(Guid.NewGuid());

        var patient = Patient.CreateNewPatient(patientId);

        patientRepository.Add(patient);
    }
}
