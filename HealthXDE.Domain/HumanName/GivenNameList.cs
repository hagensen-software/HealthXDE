using HealthXDE.Domain.Exceptions;
using System.Collections.Immutable;

namespace HealthXDE.Domain.HumanName;

public record GivenNameList
{
    private List<GivenName> givenNames;

    public GivenNameList(IEnumerable<GivenName> Names)
    {
        givenNames = new List<GivenName>(Names);
    }

    public void ThrowExceptionIfEmpty()
    {
        if (!givenNames.Any() || givenNames.All(n => string.IsNullOrWhiteSpace(n.Name)))
            throw new EmptyGivenNameException();
    }

    public ImmutableList<GivenNameType> GetGivenNames<GivenNameType>() where GivenNameType : GivenName
    {
        var result = givenNames.Where(n => n is GivenNameType).Select(n => (GivenNameType)n);
        return result.ToImmutableList();
    }
};
