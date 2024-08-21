using HealthXDE.Domain.Address;
using HealthXDE.Domain.DateTime;

namespace HealthXDE.Domain.Test.Address;

public record Address : AddressBase
{
    public Address(
        AddressUse? addressUse,
        AddressType? addressType,
        AddressText? addressText,
        AddressLineList? addressLineList,
        AddressCity? addressCity,
        AddressDistrict? addressDistrict,
        AddressState? addressState,
        AddressPostalCode? addressPostalCode,
        AddressCountry? addressCountry,
        Period? period)
        : base(addressUse, addressType, addressText, addressLineList, addressCity, addressDistrict, addressState, addressPostalCode, addressCountry, period) { }

    public AddressUse? Use => GetUse();
    public AddressType? Type => GetAddressType();
    public AddressText? Text => GetAddressText();
    public AddressLineList Lines => GetLines();
    public AddressCity? City => GetAddressCity();
    public AddressDistrict? District => GetAddressDistrict();
    public AddressState? State => GetAddressState();
    public AddressPostalCode? PostalCode => GetAddressPostalCode();
    public AddressCountry? Country => GetAddressCountry();
    public Period? Period => GetPeriod();
}
