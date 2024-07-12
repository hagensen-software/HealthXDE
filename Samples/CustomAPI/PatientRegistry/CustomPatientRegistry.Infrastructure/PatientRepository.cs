using CustomPatientRegistry.Application.Abstractions;
using CustomPatientRegistry.Domain;
using PatientRegistry.Domain;

namespace CustomPatientRegistry.Infrastructure;

internal class PatientRepository : IPatientRepository
{
    public Task<Patient> Get(PatientId id)
    {
        throw new NotImplementedException();
    }

    public Task Add(Patient patient)
    {
        throw new NotImplementedException();
    }

    public Task Remove(Patient patient)
    {
        throw new NotImplementedException();
    }

    public Task Update(Patient patient)
    {
        throw new NotImplementedException();
    }
}
