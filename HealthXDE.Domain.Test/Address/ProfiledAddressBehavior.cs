using HealthXDE.Domain.Address;
using HealthXDE.Domain.Exceptions;
using HealthXDE.Domain.Test.Address.ProfiledImplementation;

namespace HealthXDE.Domain.Test.Address;

public class ProfiledAddressBehavior
{
    [Fact]
    public void Given_AnAddressWithInvalidUseCodingCoding_When_Validated_Then_AnExceptionIsThrown()
    {
        var address = new Address(new AddressUseValueSet().Temporary, null, null, null, null, null, null, null, null, null);

        Assert.Throws<InvalidCodingException>(() => address.Validate(new ProfiledAddressValidator()));
    }

    [Fact]
    public void Given_AnAddressWithValidUseCoding_When_Validated_Then_UseIsSet()
    {
        var address = new Address(new AddressUseValueSet().Work, null, null, null, null, null, null, null, null, null);

        address.Validate(new ProfiledAddressValidator());

        Assert.Equal(new AddressUseValueSet().Work, address.Use);
    }

    [Fact]
    public void Given_AnAddressWithInvalidTypeCoding_When_Validated_Then_AnExceptionIsThrown()
    {
        var address = new Address(null, new AddressTypeValueSet().Physical, null, null, null, null, null, null, null, null);

        Assert.Throws<InvalidCodingException>(() => address.Validate(new ProfiledAddressValidator()));
    }

    [Fact]
    public void Given_AnAddressWithValidTypeCoding_When_Validated_Then_AnExceptionIsThrown()
    {
        var address = new Address(null, new AddressTypeValueSet().Postal, null, null, null, null, null, null, null, null);

        address.Validate(new ProfiledAddressValidator());

        Assert.Equal(new AddressTypeValueSet().Postal, address.Type);
    }
}
