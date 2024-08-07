using HealthXDE.Domain.CodeableConcept;

namespace HealthXDE.Domain.Gender;

public record AdministrativeGenderCode(Code? Code) : SimpleCodingBase(Code);
