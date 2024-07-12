using System.Collections.Immutable;

namespace HealthXDE.Domain.CodeableConcept;

public class ValueSet<CodingType> where CodingType : CodingBase
{
    private readonly bool required;
    protected static readonly List<CodingType> codingValues = [];

    public ValueSet(bool required)
    {
        this.required = required;
    }

    protected virtual Func<CodingBase, bool> GetFilter() => c => true;
    protected virtual ImmutableList<CodingType> GetExtensions() => [];
    protected virtual CodingType? MapCode(Code code) => null;

    internal static CodingType AddCodingValue(CodingType codingValue)
    {
        codingValues.Add(codingValue);
        return codingValue;
    }

    public ImmutableList<CodingType> GetCodingValues()
    {
        var filter = GetFilter();
        var result = codingValues.Where(c => filter(c)).ToList();
        result.AddRange(GetExtensions());
        return result.ToImmutableList();
    }

    public bool Contains(CodingType coding) => GetCodingValues().Contains(coding);

    public CodingType Lookup(Code code)
    {
        var result = GetCodingValues().FirstOrDefault(c => c.GetCode() == code);
        if (!required)
            result ??= MapCode(code);

        return result ?? throw new InvalidOperationException($"Not able to lookup code '{code}' - not found and no mapping exists");
    }

    public bool IsValid(CodingType coding)
    {
        var values = GetCodingValues();
        return values.Any(c => coding.Matches(c));
    }
}
