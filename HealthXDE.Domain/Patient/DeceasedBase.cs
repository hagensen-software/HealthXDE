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
        if (deceasedValue == null)
            return null;

        switch (deceasedValue)
        {
            case DeceasedBoolean deceased:
                return deceased;
            case DeceasedDateTime deseasedDateTime:
                return new DeceasedBoolean(true);
            default:
                return null;
        };
    }

    protected DeceasedDateTime? GetDeceasedDateTime()
    {
        if (deceasedValue == null)
            return null;

        switch (deceasedValue)
        {
            case DeceasedBoolean deceased:
                throw new InvalidOperationException("Cannot convert Deceased boolean to DeceasedDateTime");
            case DeceasedDateTime deseasedDateTime:
                return deseasedDateTime;
            default:
                return null;
        };
    }
}
