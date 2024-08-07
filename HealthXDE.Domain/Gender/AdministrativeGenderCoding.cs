using HealthXDE.Domain.CodeableConcept;

namespace HealthXDE.Domain.Gender;

public record AdministrativeGenderCoding : Coding
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
            : new AdministrativeGenderCode(code);
    }

    public static explicit operator AdministrativeGenderCoding(AdministrativeGenderCode administrativeGenderCode)
    {
        return new AdministrativeGenderCoding(null, null, administrativeGenderCode.GetCode(), null, null);
    }
}
