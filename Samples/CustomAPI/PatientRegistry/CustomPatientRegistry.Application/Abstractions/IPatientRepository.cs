using CustomPatientRegistry.Domain;
using PatientRegistry.Infrastructure.Abstractions;

namespace CustomPatientRegistry.Application.Abstractions;

public interface IPatientRepository : IPatientRepository<Patient>
{
}
