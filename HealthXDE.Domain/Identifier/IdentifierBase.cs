using HealthXDE.Domain.Abstractions;
using HealthXDE.Domain.DateTime;

namespace HealthXDE.Domain.Identifier;

public record IdentifierBase : IValidatable
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

    protected internal IdentifierUse? GetUse() => use;
    protected internal IdentifierType? GetIdentifierType() => type;
    protected internal IdentifierSystem? GetSystem() => system;
    protected internal IdentifierValue? GetValue() => value;
    protected internal Period? GetPeriod() => period;

    public void Validate(IValidator? validator = null)
    {
        validator?.Validate(this);
    }
}
