using System.Collections.Immutable;

namespace HealthXDE.Domain.CodeableConcept;

public record CodingList
{
    private readonly List<CodingBase> codings;

    public CodingList(IEnumerable<CodingBase> codings)
    {
        this.codings = new List<CodingBase>(codings);
    }

    public ImmutableList<CodingType> GetCodings<CodingType>() where CodingType : CodingBase
    {
        var result = codings.Where(n => n is CodingType).Select(n => (CodingType)n);
        return result.ToImmutableList();
    }
}
