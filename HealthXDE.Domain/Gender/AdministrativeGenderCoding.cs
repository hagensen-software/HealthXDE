using HealthXDE.Domain.Abstractions;
using HealthXDE.Domain.CodeableConcept;

namespace HealthXDE.Domain.Gender;

public record AdministrativeGenderCoding : Coding, IValidate
{
    public static readonly AdministrativeGenderValueSet ValueSets = new();

    public AdministrativeGenderCoding(CodingSystem? system, CodingVersion? version, Code? code, DisplayValue? display, UserSelected? userSelected)
        : base(system, version, code, display, userSelected)
    {
    }

    public static implicit operator AdministrativeGenderCode(AdministrativeGenderCoding administrativeGenderCoding)
    {
        var code = administrativeGenderCoding.Code;
        return code is null
            ? throw new InvalidOperationException("Cannot convert AdministrativeGenderCoding without code to AdministrativeGenderCode")
            : new AdministrativeGenderCode(code.Symbol);
    }

    public static explicit operator AdministrativeGenderCoding(AdministrativeGenderCode administrativeGenderCode)
    {
        return new AdministrativeGenderCoding(null, null, administrativeGenderCode, null, null);
    }

    public void Validate()
    {
        ThrowIfEmpty();
        ValueSets.Validate(this);
    }
}
