namespace HealthXDE.Domain.Patient;

public record DeceasedBase
{
    private readonly IDeceasedValue? deceasedValue;

    public DeceasedBase(DeceasedBoolean? deceased)
    {
        this.deceasedValue = deceased;
    }

    public DeceasedBase(DeceasedDateTime? deceasedDateTime)
    {
        this.deceasedValue = deceasedDateTime;
    }

    protected DeceasedBoolean? GetDeceased()
    {
        return deceasedValue switch
        {
            DeceasedBoolean deceased => deceased,
            DeceasedDateTime => new DeceasedBoolean(true),
            _ => null,
        };
    }

    protected DeceasedDateTime? GetDeceasedDateTime()
    {
        return deceasedValue switch
        {
            DeceasedBoolean _ => throw new InvalidOperationException("Cannot convert Deceased boolean to DeceasedDateTime"),
            DeceasedDateTime deseasedDateTime => deseasedDateTime,
            _ => null,
        };
    }
}
