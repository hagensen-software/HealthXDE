namespace HealthXDE.Domain.CodeableConcept;

public record CodeableConceptText(string Value);
public record CodingVersion(string Value);
public record DisplayValue(string Value);
public record UserSelected(bool Value);
public record Code(string Value);

public record CodingSystem(Uri Uri)
{
    public static CodingSystem FromString(string system) => new CodingSystem(new Uri(system));
}
