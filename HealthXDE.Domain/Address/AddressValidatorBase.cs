using HealthXDE.Domain.Abstractions;
using HealthXDE.Domain.Exceptions;

namespace HealthXDE.Domain.Address;

public class AddressValidatorBase : IValidator
{
    private IValidator? useValidator;
    private IValidator? addressTypeValidator;

    public AddressValidatorBase()
    {
        useValidator = GetUseValidator();
        addressTypeValidator = GetAddressTypeValidator();
    }

    public void Validate(IValidatable val)
    {
        if (val is not AddressBase address)
            throw new InvalidCodingException("AddressValidator can only validate adresses");

        address.GetUse()?.Validate(useValidator);
        address.GetAddressType()?.Validate(addressTypeValidator);
    }

    protected virtual IValidator? GetUseValidator() => null;
    protected virtual IValidator? GetAddressTypeValidator() => null;
}

public class AddressValidator : AddressValidatorBase
{
    protected override IValidator? GetUseValidator() => new AddressUseValueSet();
    protected override IValidator? GetAddressTypeValidator() => new AddressTypeValueSet();
}
