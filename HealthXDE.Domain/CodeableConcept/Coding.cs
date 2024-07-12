namespace HealthXDE.Domain.CodeableConcept;

public record Coding : CodingBase
{
    public Coding(CodingSystem? system, CodingVersion? version, Code? code, DisplayValue? display, UserSelected? userSelected)
        : base(system, version, code, display, userSelected) { }

    public CodingSystem? System => GetSystem();
    public CodingVersion? Version => GetVersion();
    public Code? Code => GetCode();
    public DisplayValue? Display => GetDisplay();
    public UserSelected? UserSelected => GetUserSelected();
}
