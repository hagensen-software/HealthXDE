using HealthXDE.Domain.DateTime;

namespace HealthXDE.Domain.ContactPoint;

public record ContactPointBase
{
    private readonly ContactPointSystem? system;
    private readonly ContactPointValue? value;
    private readonly ContactPointUse? use;
    private readonly ContactPointRank? rank;
    private readonly Period? period;

    public ContactPointBase(ContactPointSystem? system, ContactPointValue? value, ContactPointUse? use, ContactPointRank? rank, Period? period)
    {
        this.system = system;
        this.value = value;
        this.use = use;
        this.rank = rank;
        this.period = period;
    }

    protected ContactPointSystem? GetSystem() => system;
    protected ContactPointValue? GetValue() => value;
    protected ContactPointUse? GetUse() => use;
    protected ContactPointRank? GetRank() => rank;
    protected Period? GetPeriod() => period;
}
