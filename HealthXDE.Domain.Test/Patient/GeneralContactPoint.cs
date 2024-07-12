using HealthXDE.Domain.ContactPoint;
using HealthXDE.Domain.DateTime;

namespace HealthXDE.Domain.Test.Patient;

internal record GeneralContactPoint : ContactPointBase
{
    public GeneralContactPoint(ContactPointSystem? system, ContactPointValue? value, ContactPointUse? use, ContactPointRank? rank, Period? period)
        : base(system, value, use, rank, period) { }

    public ContactPointSystem? System => GetSystem();
    public ContactPointValue? Value => GetValue();
    public ContactPointUse? Use => GetUse();
    public ContactPointRank? Rank => GetRank();
    public Period? Period => GetPeriod();
}
