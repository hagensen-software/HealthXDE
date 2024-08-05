using HealthXDE.Domain.Abstractions;
using HealthXDE.Domain.CodeableConcept;

namespace HealthXDE.Domain.Gender;

public record AdministrativeGenderCode : Code
{
    public AdministrativeGenderCode(string symbol)
        : base(symbol) { }
}
