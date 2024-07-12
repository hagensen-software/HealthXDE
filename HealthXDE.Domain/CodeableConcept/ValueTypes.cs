using HealthXDE.Domain.Exceptions;

namespace HealthXDE.Domain.CodeableConcept;

public record CodeableConceptText(string Text);

public record Code(string Symbol)
{
    public void ThrowIfEmpty()
    {
        if (string.IsNullOrWhiteSpace(Symbol))
            throw new EmptyCodingException();
    }
}

public record CodingVersion(string Version);
public record DisplayValue(string Text);
public record UserSelected(bool ChosenByUser);

public record CodingSystem(Uri Uri)
{
    public static CodingSystem FromString(string system) => new CodingSystem(new Uri(system));
}
