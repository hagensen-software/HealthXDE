namespace HealthXDE.Domain.CodeableConcept;

public record CodingBase : SimpleCodingBase
{
    private readonly CodingSystem? system;
    private readonly CodingVersion? version;
    private readonly DisplayValue? display;
    private readonly UserSelected? userSelected;

    public CodingBase(CodingSystem? system, CodingVersion? version, Code? code, DisplayValue? display, UserSelected? userSelected)
        : base(code)
    {
        this.system = system;
        this.version = version;
        this.display = display;
        this.userSelected = userSelected;
    }

    protected internal CodingSystem? GetSystem() => system;
    protected internal CodingVersion? GetVersion() => version;
    protected internal DisplayValue? GetDisplay() => display;
    protected internal UserSelected? GetUserSelected() => userSelected;

    protected internal override bool Matches(SimpleCodingBase codedValue)
    {
        if (codedValue is not CodingBase)
            return base.Matches(codedValue);

        this.ThrowIfEmpty();
        codedValue.ThrowIfEmpty();

        var codingValue = codedValue as CodingBase;

        return  ((system is null) || (codingValue?.system?.Uri == system.Uri)) &&
                ((version is null) || (codingValue?.version?.Version == version.Version)) &&
                ((GetCode() is null) || (codingValue?.GetCode()?.Symbol == GetCode()?.Symbol)) &&
                ((display is null) || (codingValue?.display?.Text == display.Text)) &&
                ((userSelected is null) || ((codingValue?.userSelected?.ChosenByUser == userSelected.ChosenByUser)));
    }
}
