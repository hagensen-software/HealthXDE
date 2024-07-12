using PatientRegistry.Domain.Test.Custom;

namespace PatientRegistry.Domain.Test;

public class CustomHumanNameBehavior
{
    [Fact]
    public void When_AMinimalHumanNameIsCreated_Then_FamilyAndGivenIsSet_And_UseIsOfficial()
    {
        var family = Given.FamilyName();
        var given = Given.GivenName();

        var name = new CustomHumanName(CustomNameUse.Official, family, given);

        Assert.Equal(family, name.Familiy);
        Assert.Equal(given, name.Given);
        Assert.Equal(CustomNameUse.Official, name.Use);
    }
}
