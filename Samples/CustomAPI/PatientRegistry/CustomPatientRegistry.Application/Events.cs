using CustomPatientRegistry.Domain;
using HealthXDE.Domain.Patient;

namespace CustomPatientRegistry.Application.Events;

public record PatientRegistered(PatientId PatientId, OfficialName Name);