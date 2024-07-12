using HealthXDE.Domain.DateTime;
using HealthXDE.Domain.HumanName;

namespace CustomPatientRegistry.Domain;

public record PreviousName : HumanNameBase
{
    public PreviousName(FamilyName family, GivenNameList given, Period period)
        : base(NameUse.Old, family, given, period)
    {
        family.ThrowExceptionIfEmpty();
        given.ThrowExceptionIfEmpty();
        period.ThowExceptionIfNoEndDate();
    }
    public PreviousName(OfficialName official, DateTimeOffset end)
        : this(official.Family, official.Given, new Period(official.Start, end)) { }

    public NameUse? Use => GetUse();

    public FamilyName? Family => GetFamily();

    public GivenNameList Given => GetGiven();

    public Period Period => GetPeriod()!;
}
