using HealthXDE.Domain.CodeableConcept;

namespace HealthXDE.Domain.Address;

public class AddressUseValueSet : ValueSet<AddressUse>
{
    public AddressUseValueSet()
        : base(true) { }

    /// <summary>
    /// A communication address at a home.
    /// </summary>
    public readonly AddressUse Home = CreateCode("home");
    /// <summary>
    /// An office address. First choice for business related contacts during business hours.
    /// </summary>
    public readonly AddressUse Work = CreateCode("work");
    /// <summary>
    /// A temporary address. The period can provide more detailed information.
    /// </summary>
    public readonly AddressUse Temporary = CreateCode("temp");
    /// <summary>
    /// This address is no longer in use (or was never correct but retained for records).
    /// </summary>
    public readonly AddressUse Old = CreateCode("old");
    /// <summary>
    /// An address to be used to send bills, invoices, receipts etc.
    /// </summary>
    public readonly AddressUse Billing = CreateCode("billing");

    private static AddressUse CreateCode(string code)
    {
        return AddCodingValue(new AddressUse(new(code)));
    }
}
