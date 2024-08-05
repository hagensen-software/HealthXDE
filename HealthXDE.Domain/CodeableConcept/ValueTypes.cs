namespace HealthXDE.Domain.CodeableConcept;

public record CodeableConceptText(string Text);
public record CodingVersion(string Version);
public record DisplayValue(string Text);
public record UserSelected(bool ChosenByUser);

public record CodingSystem(Uri Uri)
{
    public static CodingSystem FromString(string system) => new CodingSystem(new Uri(system));
}
