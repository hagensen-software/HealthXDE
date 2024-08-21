using HealthXDE.Domain.Exceptions;
using System.Collections.Immutable;

namespace HealthXDE.Domain.Address;

public class AddressLineList : IEquatable<AddressLineList?>
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

    public ImmutableList<AddressLineType> GetLines<AddressLineType>() where AddressLineType : AddressLine
    {
        var result = lines.Where(n => n is AddressLineType).Select(n => (AddressLineType)n);
        return result.ToImmutableList();
    }

    public override int GetHashCode() => HashCode.Combine(lines);

    public override bool Equals(object? obj) => Equals(obj as AddressLineList);

    public bool Equals(AddressLineList? other)
    {
        return
            other is not null &&
            Enumerable.SequenceEqual(lines, other.lines);
    }

    public static bool operator ==(AddressLineList? left, AddressLineList? right)
    {
        return EqualityComparer<AddressLineList>.Default.Equals(left, right);
    }

    public static bool operator !=(AddressLineList? left, AddressLineList? right) => !(left == right);
}