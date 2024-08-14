using System.Collections.Immutable;

namespace HealthXDE.Domain.CodeableConcept;

public record CodingList<CodingBaseType> where CodingBaseType : CodingBase
{
    private readonly List<CodingBaseType> codings;

    public CodingList(IEnumerable<CodingBaseType> codings)
    {
        this.codings = new List<CodingBaseType>(codings);
    }

    public ImmutableList<CodingType> GetCodings<CodingType>() where CodingType : CodingBaseType
    {
        var result = codings.Where(n => n is CodingType).Select(n => (CodingType)n);
        return result.ToImmutableList();
    }
}
