using HealthXDE.Domain.DateTime;
using HealthXDE.Domain.HumanName;

namespace PatientRegistry.Domain.General;

public record HumanName : HumanNameBase
{
    public HumanName(NameUse? use,
                     FamilyName? family,
                     GivenNameList? given,
                     Period? period)
        : base(use, family, given, period) { }

    public NameUse? Use => GetUse();

    public FamilyName? Family => GetFamily();

    public GivenNameList Given => GetGiven();

    public Period? Period => GetPeriod();
}
