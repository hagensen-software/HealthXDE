using HealthXDE.Domain.Abstractions;
using HealthXDE.Domain.Patient;

namespace CustomPatientRegistry.Domain.Events;

public record PatientRegistered(Guid Id, PatientId PatientId, OfficialName Name) : IDomainEvent;
public record PatientNameChanged(Guid Id, OfficialName NewName) : IDomainEvent;