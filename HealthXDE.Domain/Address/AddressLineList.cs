using HealthXDE.Domain.Exceptions;
using System.Collections.Immutable;

namespace HealthXDE.Domain.Address;

public record AddressLineList
{
    private readonly List<AddressLine> lines;

    public AddressLineList(IEnumerable<AddressLine> Lines)
    {
        lines = new(Lines);
    }

    public void ThrowExceptionIfEmpty()
    {
        if (!lines.Any() || lines.All(n => string.IsNullOrWhiteSpace(n.Line)))
            throw new EmptyGivenNameException();
    }

    public ImmutableList<AddressLineType> GetGivenNames<AddressLineType>() where AddressLineType : AddressLine
    {
        var result = lines.Where(n => n is AddressLineType).Select(n => (AddressLineType)n);
        return result.ToImmutableList();
    }
}