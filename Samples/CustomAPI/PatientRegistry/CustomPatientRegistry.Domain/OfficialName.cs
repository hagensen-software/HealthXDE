using HealthXDE.Domain.DateTime;
using HealthXDE.Domain.HumanName;

namespace CustomPatientRegistry.Domain;

public record OfficialName : HumanNameBase
{
    public OfficialName(FamilyName family, GivenNameList given, DateTimeOffset? start)
        : base(NameUse.Official, family, given, new Period(start, null))
    {
        family.ThrowExceptionIfEmpty();
        given.ThrowExceptionIfEmpty();
    }

    public NameUse? Use => GetUse();

    public FamilyName Family => GetFamily()!;

    public GivenNameList Given => GetGiven();

    public DateTimeOffset? Start => GetPeriod()?.Start;
}
