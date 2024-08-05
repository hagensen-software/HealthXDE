using HealthXDE.Domain.Exceptions;
using HealthXDE.Domain.Gender;

namespace HealthXDE.Domain.Test.Patient;

public class GenderBehavior
{
    [Fact]
    public void Given_AnEmptyAdministrativeGenderCoding_When_Validated_Then_AnExceptionIsThrown()
    {
        var element = new Element<AdministrativeGenderCoding>();
        element.SetValidator(new AdministrativeGenderValueSetR5());

        var administrativeGenderCoding = new AdministrativeGenderCoding(null, null, null, null, null);

        Assert.Throws<EmptyCodingException>(() => element.Set(administrativeGenderCoding));
    }

    [Fact]
    public void Given_AnInvalidAdministrativeGenderCode_When_Validated_Then_AnExceptionIsThrown()
    {
        var element = new Element<AdministrativeGenderCode>();
        element.SetValidator(new AdministrativeGenderCodeValidator(new AdministrativeGenderValueSetR5()));

        var administrativeGenderCode = new AdministrativeGenderCode("someInvalidCode");

        Assert.Throws<InvalidCodingException>(() => element.Set(administrativeGenderCode));
    }

    [Fact]
    public void Given_AValidAdministrativeGenderCoding_When_Validated_Then_GenderIsUnchanged()
    {
        var element = new Element<AdministrativeGenderCoding>();
        element.SetValidator(new AdministrativeGenderValueSetR5());

        var administrativeGenderCoding = AdministrativeGenderValueSet.R5.Female;

        element.Set(administrativeGenderCoding);

        Assert.Equal(AdministrativeGenderValueSet.R5.Female, administrativeGenderCoding);
    }

    [Fact]
    public void Given_AnInvalidAdministrativeGenderCoding_When_Validated_Then_AnExceptionIsThrown()
    {
        var element = new Element<AdministrativeGenderCoding>();
        element.SetValidator(new AdministrativeGenderValueSetR5());

        var administrativeGenderCoding = new AdministrativeGenderCoding(null, null, new("someInvalidCode"), null, null);

        Assert.Throws<InvalidCodingException>(() => element.Set(administrativeGenderCoding));
    }

    [Fact]
    public void Given_AValidAdministrativeGenderCodingInConstrainedValueSet_When_Validated_Then_GetderIsUnchanged()
    {
        var element = new Element<SpecialAdministrativeGender>();
        element.SetValidator(new AdministrativeGenderCodeValidator(new SpecialAdministrativeGenderValueSet()));

        SpecialAdministrativeGender administrativeGenderCoding = new AdministrativeGenderValueSetR5().Male;

        element.Set(administrativeGenderCoding);

        Assert.Equal(AdministrativeGenderValueSet.R5.Male, administrativeGenderCoding);
    }

    [Fact]
    public void Given_AValidAdministrativeGenderCodingNotInValueSet_When_Validated_Then_AnExceptionIsThrown()
    {
        var element = new Element<SpecialAdministrativeGender>();
        element.SetValidator(new AdministrativeGenderCodeValidator(new SpecialAdministrativeGenderValueSet()));

        SpecialAdministrativeGender administrativeGenderCoding = new AdministrativeGenderValueSetR5().Other;

        Assert.Throws<InvalidCodingException>(() => element.Set(administrativeGenderCoding));
    }
}
