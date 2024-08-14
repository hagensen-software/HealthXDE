using HealthXDE.Domain.Abstractions;
using HealthXDE.Domain.Exceptions;

namespace HealthXDE.Domain.Identifier;

public class IdentifierValidatorBase : IValidator
{
    private IValidator? useValidator = null;
    private IValidator? identifierValidator = null;

    public IdentifierValidatorBase()
    {
        useValidator = GetUseValidator();
        identifierValidator = GetIdentifierTypeValidator();
    }

    public void Validate(IValidatable val)
    {
        if (val is not IdentifierBase identifier)
            throw new InvalidCodingException("IdentifierValidator can only validate identifiers");

        identifier.GetUse()?.Validate(useValidator);
        identifier.GetIdentifierType()?.Validate(identifierValidator);
    }

    protected virtual IValidator? GetUseValidator() => null;
    protected virtual IValidator? GetIdentifierTypeValidator() => null;
}

public class IdentifierValidator : IdentifierValidatorBase
{
    protected override IValidator? GetUseValidator() => new IdentifierUseValueSet();
    protected override IValidator? GetIdentifierTypeValidator() => new IdentifierTypeValueSet();
}