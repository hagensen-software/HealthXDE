using HealthXDE.Domain.Exceptions;

namespace HealthXDE.Domain.CodeableConcept;

public record CodingBase : CodedValue
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

    protected internal override bool Matches(CodedValue codedValue)
    {
        this.ThrowIfEmpty();
        ThrowIfEmpty(codedValue);

        return codedValue switch
        {
            CodingBase codingValue =>
                ((system is null) || (codingValue.system?.Uri == system.Uri)) &&
                ((version is null) || (codingValue.version?.Version == version.Version)) &&
                ((code is null) || (codingValue.code?.Symbol == code.Symbol)) &&
                ((display is null) || (codingValue.display?.Text == display.Text)) &&
                ((userSelected is null) || ((codingValue.userSelected?.ChosenByUser == userSelected.ChosenByUser))),
            Code codeValue => (code is null) || (codeValue.Symbol == code.Symbol),
            _ => throw new InvalidOperationException("Unkown type of CodedValue received")
        };
    }

    private static void ThrowIfEmpty(CodedValue codedValue)
    {
        _ = CodedValue.GetCodeSymbol(codedValue);
    }
}
