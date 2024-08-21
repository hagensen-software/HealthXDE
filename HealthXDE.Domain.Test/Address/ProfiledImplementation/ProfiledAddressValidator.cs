using HealthXDE.Domain.Abstractions;
using HealthXDE.Domain.Address;

namespace HealthXDE.Domain.Test.Address.ProfiledImplementation;

public class ProfiledAddressValidator : AddressValidatorBase
{
    protected override IValidator? GetUseValidator() => new ProfiledAddressUseValueSet();
    protected override IValidator? GetAddressTypeValidator() => new ProfiledAddressTypeValueSet();
}
