using HealthXDE.Domain.Exceptions;

namespace HealthXDE.Domain.Gender;

public class AdministrativeGenderValueSet
{
    public static AdministrativeGenderValueSetR4 R4 = new();
    public static AdministrativeGenderValueSetR5 R5 = new();

    public static void OverrideR4ValueSet<AdministrativeGenderValueSetR4Type>(AdministrativeGenderValueSetR4Type r4)
        where AdministrativeGenderValueSetR4Type : AdministrativeGenderValueSetR4 => R4 = r4;
    public static void OverrideR5ValueSet<AdministrativeGenderValueSetR5Type>(AdministrativeGenderValueSetR5Type r5)
        where AdministrativeGenderValueSetR5Type : AdministrativeGenderValueSetR5 => R5 = r5;

    public AdministrativeGenderCoding MapToR4(AdministrativeGenderCoding administrativeGenderCoding)
    {
        var code = administrativeGenderCoding.GetCode() ?? throw new InvalidOperationException("Cannot map coding with no code");

        if (R4.Contains(administrativeGenderCoding))
            return administrativeGenderCoding;

        if (R5.Contains(administrativeGenderCoding))
            return R4.Lookup(code);

        throw new InvalidOperationException($"Cannot map coding - code '{code}' not found");
    }

    public AdministrativeGenderCoding MapToR5(AdministrativeGenderCoding administrativeGenderCoding)
    {
        var code = administrativeGenderCoding.GetCode() ?? throw new InvalidOperationException("Cannot map coding with no code");

        if (R5.Contains(administrativeGenderCoding))
            return administrativeGenderCoding;

        if (R4.Contains(administrativeGenderCoding))
            return R5.Lookup(code);

        throw new InvalidOperationException($"Cannot map coding - code '{code}' not found");
    }

    public void Validate(AdministrativeGenderCoding administrativeGenderCoding)
    {
        if (!R4.IsValid(administrativeGenderCoding) &&
            !R5.IsValid(administrativeGenderCoding))
        {
            throw new InvalidCodingException($"Code '{administrativeGenderCoding.Code?.Symbol}' is not a valid AdministrativeGender code");
        }
    }
}
