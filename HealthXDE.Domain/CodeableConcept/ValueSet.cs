using HealthXDE.Domain.Abstractions;
using HealthXDE.Domain.Exceptions;
using System.Collections.Immutable;

namespace HealthXDE.Domain.CodeableConcept;

public class ValueSet<CodingType> : IValidator<CodingType>
    where CodingType : CodedValue
{
    private readonly bool required;
    protected static readonly List<CodingType> codingValues = [];

    public ValueSet(bool required)
    {
        this.required = required;
    }

    protected virtual Func<CodingType, bool> GetFilter() => c => true;
    protected virtual ImmutableList<CodingType> GetExtensions() => [];
    protected virtual CodingType? MapCode(Code code) => null;

    protected static CodingType AddCodingValue(CodingType codingValue)
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
        var result = GetCodingValues().FirstOrDefault(c => CodedValue.GetCodeSymbol(c) == code.Symbol);
        if (!required)
            result ??= MapCode(code);

        return result ?? throw new InvalidOperationException($"Not able to lookup code '{code}' - not found and no mapping exists");
    }

    public bool IsValid(CodingType coding)
    {
        var values = GetCodingValues();
        return values.Exists(c => coding.Matches(c));
    }

    public void Validate(CodingType coding)
    {
        if (!IsValid(coding))
            throw new InvalidCodingException($"Code '{CodedValue.GetCodeSymbol(coding)}' is not a valid code");
    }
}
