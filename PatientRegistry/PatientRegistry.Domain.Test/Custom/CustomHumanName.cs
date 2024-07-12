using HealthXDE.Domain.HumanName;

namespace PatientRegistry.Domain.Test.Custom;

public record CustomHumanName : HumanNameBase
{
    public CustomHumanName(CustomNameUse use, FamilyName family, GivenNameList given)
        : base((NameUse)use, family, given, null)
    {
    }

    public CustomNameUse Use => ((CustomNameUse?)GetUse()) ?? throw new InvalidOperationException("Mandatory Use property not set");
    public FamilyName Familiy => GetFamily() ?? throw new InvalidOperationException("Mandatory Family property not set");
    public GivenNameList Given => GetGiven();
}
