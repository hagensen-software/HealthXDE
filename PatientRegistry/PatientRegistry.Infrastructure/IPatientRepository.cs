using PatientRegistry.Domain;
using PatientRegistry.Domain.Base;

namespace PatientRegistry.Infrastructure;

public interface IPatientRepository<PatientType> where PatientType : PatientBase
{
    Task<PatientType> Get(PatientId id);

    Task Add(PatientType patient);
    Task Update(PatientType patient);
    Task Remove(PatientType patient);
}
