using HealthXDE.Domain.DateTime;

namespace HealthXDE.Domain.HumanName;

public record HumanNameBase
{
    private readonly NameUse? use;
    private readonly FamilyName? family;
    private readonly GivenNameList given;
    private readonly Period? period;

    public HumanNameBase(NameUse? use, FamilyName? family, GivenNameList? given, Period? period)
    {
        this.use = use;
        this.family = family;
        this.given = given ?? new GivenNameList([]);
        this.period = period;
    }

    protected NameUse? GetUse() => use;

    protected FamilyName? GetFamily() => family;
    protected GivenNameList GetGiven() => given;
    protected Period? GetPeriod() => period;
}
