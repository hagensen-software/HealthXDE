using HealthXDE.Domain.Address;
using HealthXDE.Domain.CodeableConcept;
using HealthXDE.Domain.DateTime;
using HealthXDE.Domain.Exceptions;

namespace HealthXDE.Domain.Test.Address;

public class AddressBehavior
{
    [Fact]
    public void Given_AnEmptyAddress_When_Validated_Then_AddressIsEmpty()
    {
        var address = new Address(null, null, null, null, null, null, null, null, null, null);

        address.Validate(new AddressValidator());

        Assert.Null(address.Use);
        Assert.Null(address.Type);
        Assert.Null(address.Text);
        Assert.Empty(address.Lines.GetLines<AddressLine>());
        Assert.Null(address.City);
        Assert.Null(address.District);
        Assert.Null(address.State);
        Assert.Null(address.PostalCode);
        Assert.Null(address.Country);
        Assert.Null(address.Period);
    }

    [Fact]
    public void Given_AValidAddressWithAllSet_When_Validated_Then_AddressHasAllSet()
    {
        var address = new Address(
            new AddressUseValueSet().Work,
            new AddressTypeValueSet().Postal,
            new AddressText("Some address"),
            new AddressLineList([new AddressLine("Some address line")]),
            new AddressCity("Some city"),
            new AddressDistrict("Some district"),
            new AddressState("Some state"),
            new AddressPostalCode("Some postal code"),
            new AddressCountry("Some country"),
            new Period(null, null));

        address.Validate(new AddressValidator());

        Assert.Equal(new AddressUseValueSet().Work, address.Use);
        Assert.Equal(new AddressTypeValueSet().Postal, address.Type);
        Assert.Equal(new AddressText("Some address"), address.Text);
        Assert.Equal(new AddressLineList([new AddressLine("Some address line")]), address.Lines);
        Assert.Equal(new AddressCity("Some city"), address.City);
        Assert.Equal(new AddressDistrict("Some district"), address.District);
        Assert.Equal(new AddressState("Some state"), address.State);
        Assert.Equal(new AddressPostalCode("Some postal code"), address.PostalCode);
        Assert.Equal(new AddressCountry("Some country"), address.Country);
        Assert.Equal(new Period(null, null), address.Period);
    }

    [Fact]
    public void Given_AnAddressWithEmptyUseCoding_When_Validated_Then_AnExceptionIsThrown()
    {
        var address = new Address(new AddressUse(new Code("")), null, null, null, null, null, null, null, null, null);

        Assert.Throws<EmptyCodingException>(() => address.Validate(new AddressValidator()));
    }

    [Fact]
    public void Given_AnAddressWithInvalidUseCodingCoding_When_Validated_Then_AnExceptionIsThrown()
    {
        var address = new Address(new AddressUse(new Code("someInvalidCode")), null, null, null, null, null, null, null, null, null);

        Assert.Throws<InvalidCodingException>(() => address.Validate(new AddressValidator()));
    }

    [Fact]
    public void Given_AnAddressWithValidUseCoding_When_Validated_Then_UseIsSet()
    {
        var address = new Address(new AddressUseValueSet().Work, null, null, null, null, null, null, null, null, null);

        address.Validate(new AddressValidator());

        Assert.Equal(new AddressUseValueSet().Work, address.Use);
    }

    [Fact]
    public void Given_AnAddressWithEmptyTypeCoding_When_Validated_Then_AnExceptionIsThrown()
    {
        var address = new Address(null, new AddressType(new Code("")), null, null, null, null, null, null, null, null);

        Assert.Throws<EmptyCodingException>(() => address.Validate(new AddressValidator()));
    }

    [Fact]
    public void Given_AnAddressWithInvalidTypeCodingCoding_When_Validated_Then_AnExceptionIsThrown()
    {
        var address = new Address(null, new AddressType(new Code("someInvalidCode")), null, null, null, null, null, null, null, null);

        Assert.Throws<InvalidCodingException>(() => address.Validate(new AddressValidator()));
    }
}
