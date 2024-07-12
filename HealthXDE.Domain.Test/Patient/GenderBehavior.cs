using HealthXDE.Domain.Exceptions;
using HealthXDE.Domain.Gender;

namespace HealthXDE.Domain.Test.Patient;

public class GenderBehavior
{
    [Fact]
    public void Given_AnEmptyAdministrativeGenderCoding_When_Validated_Then_AnExceptionIsThrown()
    {
        var administrativeGenderCoding = new AdministrativeGenderCoding(null, null, null, null, null);

        Assert.Throws<EmptyCodingException>(() => administrativeGenderCoding.Validate());
    }

    [Fact]
    public void Given_AnInvalidAdministrativeGenderCode_When_Validated_Then_AnExceptionIsThrown()
    {
        var administrativeGenderCode = new AdministrativeGenderCode("someInvalidCode");

        Assert.Throws<InvalidCodingException>(() => administrativeGenderCode.Validate());
    }

    [Fact]
    public void Given_AValidAdministrativeGenderCoding_When_Validated_Then_GenderIsUnchanged()
    {
        var administrativeGenderCoding = AdministrativeGenderValueSet.R5.Female;

        administrativeGenderCoding.Validate();

        Assert.Equal(AdministrativeGenderValueSet.R5.Female, administrativeGenderCoding);
    }

    [Fact]
    public void Given_AnInvalidAdministrativeGenderCoding_When_Validated_Then_AnExceptionIsThrown()
    {
        var administrativeGenderCoding = new AdministrativeGenderCoding(null, null, new("someInvalidCode"), null, null);

        Assert.Throws<InvalidCodingException>(() => administrativeGenderCoding.Validate());
    }
}
