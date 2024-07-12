namespace CustomPatientRegistry.Application.Events;

public record PatientRegistered(PatientId PatientId, HumanName Name);