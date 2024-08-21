using HealthXDE.Domain.Address;

namespace HealthXDE.Domain.Test.Address.ProfiledImplementation;

public class ProfiledAddressUseValueSet : AddressUseValueSet
{
    internal static readonly string[] sourceArray = ["work"];

    protected override Func<AddressUse, bool> GetFilter()
    {
        return c => sourceArray.Contains(c.Code?.Value);
    }
}
