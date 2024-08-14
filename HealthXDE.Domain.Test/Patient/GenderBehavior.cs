using HealthXDE.Domain.Exceptions;
using HealthXDE.Domain.Gender;
using HealthXDE.Domain.Test.Patient.ProfiledImplementation;

namespace HealthXDE.Domain.Test.Patient;

public class GenderBehavior
{
    [Fact]
    public void Given_AnEmptyAdministrativeGenderCoding_When_Validated_Then_AnExceptionIsThrown()
    {
        var element = new Element<AdministrativeGenderCoding>();
        element.SetValidator(new AdministrativeGenderValueSet());

        var administrativeGenderCoding = new AdministrativeGenderCoding(null, null, null, null, null);

        Assert.Throws<EmptyCodingException>(() => element.Set(administrativeGenderCoding));
    }

    [Fact]
    public void Given_AnInvalidAdministrativeGenderCode_When_Validated_Then_AnExceptionIsThrown()
    {
        var element = new Element<AdministrativeGenderCode>();
        element.SetValidator(new AdministrativeGenderValueSet());

        var administrativeGenderCode = new AdministrativeGenderCode(new("someInvalidCode"));

        Assert.Throws<InvalidCodingException>(() => element.Set(administrativeGenderCode));
    }

    [Fact]
    public void Given_AValidAdministrativeGenderCoding_When_Validated_Then_GenderIsUnchanged()
    {
        var element = new Element<AdministrativeGenderCoding>();
        element.SetValidator(new AdministrativeGenderValueSet());

        var administrativeGenderCoding = AdministrativeGenderCoding.ValueSet.Female;

        element.Set(administrativeGenderCoding);

        Assert.Equal(AdministrativeGenderCoding.ValueSet.Female, administrativeGenderCoding);
    }

    [Fact]
    public void Given_AnInvalidAdministrativeGenderCoding_When_Validated_Then_AnExceptionIsThrown()
    {
        var element = new Element<AdministrativeGenderCoding>();
        element.SetValidator(new AdministrativeGenderValueSet());

        var administrativeGenderCoding = new AdministrativeGenderCoding(null, null, new("someInvalidCode"), null, null);

        Assert.Throws<InvalidCodingException>(() => element.Set(administrativeGenderCoding));
    }

    [Fact]
    public void Given_AValidAdministrativeGenderCodingInConstrainedValueSet_When_Validated_Then_GenderIsUnchanged()
    {
        var element = new Element<ProfiledAdministrativeGender>();
        element.SetValidator(new ProfiledAdministrativeGenderValueSet());

        ProfiledAdministrativeGender administrativeGenderCoding = new AdministrativeGenderValueSet().Male;

        element.Set(administrativeGenderCoding);

        Assert.Equal(AdministrativeGenderCoding.ValueSet.Male, administrativeGenderCoding);
    }

    [Fact]
    public void Given_AValidAdministrativeGenderCodingNotInValueSet_When_Validated_Then_AnExceptionIsThrown()
    {
        var element = new Element<ProfiledAdministrativeGender>();
        element.SetValidator(new ProfiledAdministrativeGenderValueSet());

        ProfiledAdministrativeGender administrativeGenderCoding = new AdministrativeGenderValueSet().Other;

        Assert.Throws<InvalidCodingException>(() => element.Set(administrativeGenderCoding));
    }
}
