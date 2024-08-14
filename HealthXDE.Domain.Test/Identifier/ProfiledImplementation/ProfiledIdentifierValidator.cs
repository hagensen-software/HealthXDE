using HealthXDE.Domain.Abstractions;
using HealthXDE.Domain.Identifier;

namespace HealthXDE.Domain.Test.Identifier.ProfiledImplementation;

public class ProfiledIdentifierValidator : IdentifierValidatorBase
{
    protected override IValidator? GetUseValidator() => new ProfiledIdentifierUseValueSet();
    protected override IValidator? GetIdentifierTypeValidator() => new ProfiledIdentifierTypeValueSet();
}
