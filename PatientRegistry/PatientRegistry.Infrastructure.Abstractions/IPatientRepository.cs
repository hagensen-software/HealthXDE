using HealthXDE.Domain.Patient;

namespace PatientRegistry.Infrastructure.Abstractions;

public interface IPatientRepository<PatientType> where PatientType : PatientBase
{
    Task<PatientType> Get(PatientId id);

    Task Add(PatientType patient);
    Task Update(PatientType patient);
    Task Remove(PatientType patient);
}