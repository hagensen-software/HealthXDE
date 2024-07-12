using HealthXDE.Domain.Exceptions;

namespace HealthXDE.Domain.CodeableConcept;

public record CodingBase
{
    private readonly CodingSystem? system;
    private readonly CodingVersion? version;
    private readonly Code? code;
    private readonly DisplayValue? display;
    private readonly UserSelected? userSelected;

    public CodingBase(CodingSystem? system, CodingVersion? version, Code? code, DisplayValue? display, UserSelected? userSelected)
    {
        this.system = system;
        this.version = version;
        this.code = code;
        this.display = display;
        this.userSelected = userSelected;
    }

    protected internal void ThrowIfEmpty()
    {
        if (code is null)
            throw new EmptyCodingException();
    }

    protected internal CodingSystem? GetSystem() => system;
    protected internal CodingVersion? GetVersion() => version;
    protected internal Code? GetCode() => code;
    protected internal DisplayValue? GetDisplay() => display;
    protected internal UserSelected? GetUserSelected() => userSelected;

    protected internal virtual bool Matches(CodingBase coding)
    {
        coding.ThrowIfEmpty();

        return
            ((system is null) || (coding.system?.Uri == system.Uri)) &&
            ((version is null) || (coding.version?.Version == version.Version)) &&
            ((code is null) || (coding.code?.Symbol == code.Symbol)) &&
            ((display is null) || (coding.display?.Text == display.Text)) &&
            ((userSelected is null) || ((coding.userSelected?.ChosenByUser == userSelected.ChosenByUser)));
    }
}
