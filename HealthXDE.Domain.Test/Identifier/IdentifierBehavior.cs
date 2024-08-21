using HealthXDE.Domain.CodeableConcept;
using HealthXDE.Domain.Exceptions;
using HealthXDE.Domain.Identifier;

namespace HealthXDE.Domain.Test.Identifier;

public class IdentifierBehavior
{
    [Fact]
    public void Given_AnIdentifierWithNoCodings_When_Validated_Then_IdentifierIsEmpty()
    {
        var identifier = new Identifier(null, null, null, null, null);

        identifier.Validate(new IdentifierValidator());

        Assert.Null(identifier.Use);
        Assert.Null(identifier.Type);
        Assert.Null(identifier.System);
        Assert.Null(identifier.Value);
        Assert.Null(identifier.Period);
    }

    [Fact]
    public void Given_AnIdentifierWithEmptyUseCoding_When_Validated_Then_AnExceptionIsThrown()
    {
        var identifier = new Identifier(new IdentifierUse(new CodeableConcept.Code("")), null, null, null, null);

        Assert.Throws<EmptyCodingException>(() => identifier.Validate(new IdentifierValidator()));
    }

    [Fact]
    public void Given_AnIdentifierWithInvalidUseCodingCoding_When_Validated_Then_AnExceptionIsThrown()
    {
        var identifier = new Identifier(new IdentifierUse(new CodeableConcept.Code("someInvalidCode")), null, null, null, null);

        Assert.Throws<InvalidCodingException>(() => identifier.Validate(new IdentifierValidator()));
    }

    [Fact]
    public void Given_AnIdentifierWithValidUseCoding_When_Validated_Then_UseIsSet()
    {
        var identifier = new Identifier(new IdentifierUseValueSet().Official, null, null, null, null);

        identifier.Validate(new IdentifierValidator());

        Assert.Equal(new IdentifierUseValueSet().Official, identifier.Use);
    }

    [Fact]
    public void Given_AnIdentifierWithNoTypeCoding_When_Validated_Then_IdentifierHasNoType()
    {
        var identifier = new Identifier(null, new IdentifierType(new([]), null), null, null, null);

        identifier.Validate(new IdentifierValidator());

        var codings = identifier.Type?.Codings.GetCodings<IdentifierTypeCoding>();

        Assert.NotNull(codings);
        Assert.Empty(codings);
    }

    [Fact]
    public void Given_AnIdentifierWithEmptyTypeCoding_When_Validated_Then_AnExceptionIsThrown()
    {
        var codings = new CodingList<IdentifierTypeCoding>([new IdentifierTypeCoding(null, null, null, null, null)]);
        var identifier = new Identifier(null, new IdentifierType(codings, null), null, null, null);

        Assert.Throws<EmptyCodingException>(() => identifier.Validate(new IdentifierValidator()));
    }

    [Fact]
    public void Given_AnIdentifierWithInvalidTypeCoding_When_Validated_Then_AnExceptionIsThrown()
    {
        var codings = new CodingList<IdentifierTypeCoding>([new IdentifierTypeCoding(null, null, new Code("someInvalidCode"), null, null)]);
        var identifier = new Identifier(null, new IdentifierType(codings, null), null, null, null);

        Assert.Throws<InvalidCodingException>(() => identifier.Validate(new IdentifierValidator()));
    }

    [Fact]
    public void Given_AnIdentifierWithValidTypeCoding_When_Validated_Then_TypeIsSet()
    {
        var codings = new CodingList<IdentifierTypeCoding>([new IdentifierTypeValueSet().DriversLicenseNumber]);
        var identifier = new Identifier(null, new IdentifierType(codings, null), null, null, null);

        identifier.Validate(new IdentifierValidator());

        Assert.Equal(new IdentifierTypeValueSet().DriversLicenseNumber, identifier.Type?.Codings.GetCodings<IdentifierTypeCoding>().First());
    }

    [Fact]
    public void Given_AnIdentifierWithText_When_Validated_Then_TextIsSet()
    {
        var identifier = new Identifier(null, new IdentifierType(new([]), new("Some text")), null, null, null);

        identifier.Validate(new IdentifierValidator());

        Assert.Equal("Some text", identifier.Type?.Text?.Value);
    }
}
