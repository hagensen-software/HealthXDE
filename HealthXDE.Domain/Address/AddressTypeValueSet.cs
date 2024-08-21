using HealthXDE.Domain.CodeableConcept;

namespace HealthXDE.Domain.Address;

public class AddressTypeValueSet : ValueSet<AddressType>
{
    public AddressTypeValueSet()
        : base(true) { }

    /// <summary>
    /// Mailing addresses - PO Boxes and care-of addresses.
    /// </summary>
    public readonly AddressType Postal = CreateCode("postal");
    /// <summary>
    /// A physical address that can be visited.
    /// </summary>
    public readonly AddressType Physical = CreateCode("physical");
    /// <summary>
    /// An address that is both physical and postal.
    /// </summary>
    public readonly AddressType Both = CreateCode("both");

    private static AddressType CreateCode(string code)
    {
        return AddCodingValue(new AddressType(new(code)));
    }
}
