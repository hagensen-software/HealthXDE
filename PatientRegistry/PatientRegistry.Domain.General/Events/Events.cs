using HealthXDE.Domain.Abstractions;
using HealthXDE.Domain.Gender;
using HealthXDE.Domain.Patient;

namespace PatientRegistry.Domain.General.Events;

public record PatientRegistered(Guid Id, PatientId PatientId) : IDomainEvent;
public record PatientNameAdded<HumanNameType>(Guid Id, PatientId PatientId, HumanNameType Name) : IDomainEvent
    where HumanNameType : HumanName;
public record PatientGenderChanged(Guid Id, PatientId PatientId, AdministrativeGenderCoding Gender) : IDomainEvent;
