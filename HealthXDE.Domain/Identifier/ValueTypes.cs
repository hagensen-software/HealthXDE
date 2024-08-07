using HealthXDE.Domain.CodeableConcept;

namespace HealthXDE.Domain.Identifier;

public record IdentifierType(CodingList Codings, CodeableConceptText? Text) : ICodeableConcept;
public record IdentifierValue(string Value);

public record IdentifierSystem(Uri Uri)
{
    public static IdentifierSystem FromString(string system) => new IdentifierSystem(new Uri(system));
}
