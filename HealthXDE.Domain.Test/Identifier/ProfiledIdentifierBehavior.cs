using HealthXDE.Domain.CodeableConcept;
using HealthXDE.Domain.Exceptions;
using HealthXDE.Domain.Identifier;
using HealthXDE.Domain.Test.Identifier.ProfiledImplementation;

namespace HealthXDE.Domain.Test.Identifier;

public class ProfiledIdentifierBehavior
{
    [Fact]
    public void Given_AnIdentifierWithInvalidUseCodingCoding_When_Validated_Then_AnExceptionIsThrown()
    {
        var identifier = new ProfiledIdentifier(new IdentifierUseValueSet().Usual, null, null, null, null);

        Assert.Throws<InvalidCodingException>(() => identifier.Validate(new ProfiledIdentifierValidator()));
    }

    [Fact]
    public void Given_AnIdentifierWithValidUseCoding_When_Validated_Then_UseIsSet()
    {
        var identifier = new ProfiledIdentifier(new IdentifierUseValueSet().Official, null, null, null, null);

        identifier.Validate(new ProfiledIdentifierValidator());

        Assert.Equal(new IdentifierUseValueSet().Official, identifier.Use);
    }

    [Fact]
    public void Given_AnIdentifierWithInvalidTypeCoding_When_Validated_Then_AnExceptionIsThrown()
    {
        var codings = new CodingList<IdentifierTypeCoding>([new IdentifierTypeValueSet().ProviderNumber]);
        var identifier = new ProfiledIdentifier(null, new IdentifierType(codings, null), null, null, null);

        Assert.Throws<InvalidCodingException>(() => identifier.Validate(new ProfiledIdentifierValidator()));
    }

    [Fact]
    public void Given_AnIdentifierWithValidTypeCoding_When_Validated_Then_TypeIsSet()
    {
        var codings = new CodingList<IdentifierTypeCoding>([new ProfiledDriversLicenseTypeCoding()]);
        var identifier = new ProfiledIdentifier(null, new IdentifierType(codings, null), null, null, null);

        identifier.Validate(new ProfiledIdentifierValidator());

        Assert.Equal(new ProfiledDriversLicenseTypeCoding(), identifier.Type?.Codings.GetCodings<ProfiledDriversLicenseTypeCoding>().First());
    }

    [Fact]
    public void Given_AnIdentifierWithExtendedTypeCoding_When_Validated_Then_TypeIsSet()
    {
        var codings = new CodingList<IdentifierTypeCoding>([new ProfiledBankCardTypeCoding()]);
        var identifier = new ProfiledIdentifier(null, new IdentifierType(codings, null), null, null, null);

        identifier.Validate(new ProfiledIdentifierValidator());

        Assert.Equal(new ProfiledBankCardTypeCoding(), identifier.Type?.Codings.GetCodings<ProfiledBankCardTypeCoding>().First());
    }
}
