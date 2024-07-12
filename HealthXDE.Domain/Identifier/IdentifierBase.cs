using HealthXDE.Domain.DateTime;

namespace HealthXDE.Domain.Identifier;

public record IdentifierBase
{
    private readonly IdentifierUse? use;
    private readonly IdentifierType? type;
    private readonly IdentifierSystem? system;
    private readonly IdentifierValue? value;
    private readonly Period? period;

    // TODO: Assigner

    public IdentifierBase(IdentifierUse? use, IdentifierType? type, IdentifierSystem? system, IdentifierValue? value, Period? period)
    {
        this.use = use;
        this.type = type;
        this.system = system;
        this.value = value;
        this.period = period;
    }

    protected IdentifierUse? GetUse() => use;
    protected IdentifierType? GetIdentifierType() => type;
    protected IdentifierSystem? GetSystem() => system;
    protected IdentifierValue? GetValue() => value;
    protected Period? GetPeriod() => period;
}
