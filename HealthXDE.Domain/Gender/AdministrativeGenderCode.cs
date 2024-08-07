using HealthXDE.Domain.CodeableConcept;

namespace HealthXDE.Domain.Gender;

public record AdministrativeGenderCode : SimpleCodingBase
{
    public AdministrativeGenderCode(Code? code)
        : base(code) { }
}
