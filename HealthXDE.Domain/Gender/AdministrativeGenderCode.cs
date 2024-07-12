using HealthXDE.Domain.Abstractions;
using HealthXDE.Domain.CodeableConcept;

namespace HealthXDE.Domain.Gender;

public record AdministrativeGenderCode : Code, IValidate
{
    public AdministrativeGenderCode(string symbol)
        : base(symbol)
    {
    }

    public static readonly AdministrativeGenderValueSet ValueSets = new();

    public void Validate()
    {
        ThrowIfEmpty();
        ValueSets.Validate((AdministrativeGenderCoding)this);
    }
}
