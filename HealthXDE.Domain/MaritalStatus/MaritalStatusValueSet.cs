namespace HealthXDE.Domain.MaritalStatus;

public class MaritalStatusValueSet
{
    public static MaritalStatusValueSetR4 R4 = new();
    public static MaritalStatusValueSetR5 R5 = new();

    public static void OverrideR4ValueSet<MaritalStatusValueSetR4Type>(MaritalStatusValueSetR4Type r4)
        where MaritalStatusValueSetR4Type : MaritalStatusValueSetR4 => R4 = r4;
    public static void OverrideR5ValueSet<MaritalStatusValueSetR5Type>(MaritalStatusValueSetR5Type r5)
        where MaritalStatusValueSetR5Type : MaritalStatusValueSetR5 => R5 = r5;

    public MaritalStatusCoding MapToR4(MaritalStatusCoding maritalStatusCoding)
    {
        var code = maritalStatusCoding.GetCode() ?? throw new InvalidOperationException("Cannot map coding with no code");

        if (R4.Contains(maritalStatusCoding))
            return maritalStatusCoding;

        if (R5.Contains(maritalStatusCoding))
        {
            if (maritalStatusCoding == R5.CommonLaw)
                return R4.Married; // Return level 1 code for non-existing level 2 code

            return R4.Lookup(code);
        }

        throw new InvalidOperationException($"Cannot map coding - code '{code}' not found");
    }

    public MaritalStatusCoding MapToR5(MaritalStatusCoding maritalStatusCoding)
    {
        var code = maritalStatusCoding.GetCode() ?? throw new InvalidOperationException("Cannot map coding with no code");

        if (R5.Contains(maritalStatusCoding))
            return maritalStatusCoding;

        if (R4.Contains(maritalStatusCoding))
            return R5.Lookup(code);

        throw new InvalidOperationException($"Cannot map coding - code '{code}' not found");
    }
}
