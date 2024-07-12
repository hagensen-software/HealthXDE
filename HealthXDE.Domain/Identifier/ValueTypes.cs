using HealthXDE.Domain.CodeableConcept;

namespace HealthXDE.Domain.Identifier;

public enum IdentifierUse
{
    Usual,
    Official,
    Temp,
    Secondary,
    Old
}

public record IdentifierType(CodingList Codings, CodeableConceptText? Text) : ICodeableConcept;
public record IdentifierValue(string Value);

public record IdentifierSystem(Uri uri)
{
    public static IdentifierSystem FromString(string system) => new IdentifierSystem(new Uri(system));
}
