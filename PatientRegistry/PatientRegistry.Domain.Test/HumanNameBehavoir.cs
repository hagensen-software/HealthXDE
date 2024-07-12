using HealthXDE.Domain.HumanName;
using PatientRegistry.Domain.General;

namespace PatientRegistry.Domain.Test;

public class HumanNameBehavoir
{
    [Fact]
    public void When_AMinimalHumanNameIsCreated_Then_ItSucceeds()
    {
        var name = new HumanName(null, null, null, null);

        Assert.Null(name.Use);
        Assert.Null(name.Family);
        Assert.Empty(name.Given.GetGivenNames<GivenName>());
    }

    [Fact]
    public void When_AHumanName_IsCreatedWithAUse_Then_TheUseIsSet()
    {
        var name = new HumanName(NameUse.Official, null, null, null);

        Assert.Equal(NameUse.Official, name.Use);
        Assert.Null(name.Family);
        Assert.Empty(name.Given.GetGivenNames<GivenName>());
    }

    [Fact]
    public void When_AHumanName_IsCreatedWithAFamilyName_Then_TheFamilyNameIsSet()
    {
        var family = Given.FamilyName();

        var name = new HumanName(null, family, null, null);

        Assert.Null(name.Use);
        Assert.Equal(family, name.Family);
        Assert.Empty(name.Given.GetGivenNames<GivenName>());
    }

    [Fact]
    public void When_AHumanName_IsCreatedWithAGivenName_Then_TheGivenNameIsSet()
    {
        var given = Given.GivenName();

        var name = new HumanName(null, null, given, null);

        Assert.Null(name.Use);
        Assert.Null(name.Family);
        Assert.Equal(given, name.Given);
    }
}
