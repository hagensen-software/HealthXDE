using HealthXDE.Domain.Address;

namespace HealthXDE.Domain.Test.Address.ProfiledImplementation;

public class ProfiledAddressTypeValueSet : AddressTypeValueSet
{
    internal static readonly string[] sourceArray = ["postal"];

    protected override Func<AddressType, bool> GetFilter()
    {
        return c => sourceArray.Contains(c.Code?.Value);
    }
}
