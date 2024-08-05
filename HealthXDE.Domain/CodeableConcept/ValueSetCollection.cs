namespace HealthXDE.Domain.CodeableConcept;

public class ValueSetCollection<CodingType>(ValueSet<CodingType> r4, ValueSet<CodingType> r5)
    where CodingType : Coding
{
    private ValueSet<CodingType> r4 = r4;
    private ValueSet<CodingType> r5 = r5;

    public CodingType MapToR4(CodingType coding)
    {
        var code = coding.GetCode() ?? throw new InvalidOperationException("Cannot map coding with no code");

        if (r4.Contains(coding))
            return coding;

        if (r5.Contains(coding))
            return r4.Lookup(code);

        throw new InvalidOperationException($"Cannot map coding - code '{code}' not found");
    }

    public CodingType MapToR5(CodingType coding)
    {
        var code = coding.GetCode() ?? throw new InvalidOperationException("Cannot map coding with no code");

        if (r5.Contains(coding))
            return coding;

        if (r4.Contains(coding))
            return r5.Lookup(code);

        throw new InvalidOperationException($"Cannot map coding - code '{code}' not found");
    }
}
