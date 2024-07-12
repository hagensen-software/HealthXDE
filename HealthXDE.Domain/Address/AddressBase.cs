using HealthXDE.Domain.DateTime;

namespace HealthXDE.Domain.Address;

public record AddressBase
{
    private readonly AddressUse? addressUse;
    private readonly AddressType? addressType;
    private readonly AddressText? addressText;
    private readonly AddressLineList addressLineList;
    private readonly AddressCity? addressCity;
    private readonly AddressDistrict? addressDistrict;
    private readonly AddressState? addressState;
    private readonly AddressPostalCode? addressPostalCode;
    private readonly AddressCountry? addressCountry;
    private readonly Period? period;

    public AddressBase(
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
    {
        this.addressUse = addressUse;
        this.addressType = addressType;
        this.addressText = addressText;
        this.addressLineList = addressLineList ?? new([]);
        this.addressCity = addressCity;
        this.addressDistrict = addressDistrict;
        this.addressState = addressState;
        this.addressPostalCode = addressPostalCode;
        this.addressCountry = addressCountry;
        this.period = period;
    }

    protected AddressUse? GetUse() => addressUse;
    protected AddressType? GetAddressType() => addressType;
    protected AddressText? GetAddressText() => addressText;
    protected AddressLineList GetLines() => addressLineList;
    protected AddressCity? GetAddressCity() => addressCity;
    protected AddressDistrict? GetAddressDistrict() => addressDistrict;
    protected AddressState? GetAddressState() => addressState;
    protected AddressPostalCode? GetAddressPostalCode() => addressPostalCode;
    protected AddressCountry? GetAddressCountry() => addressCountry;
    protected Period? GetPeriod() => period;
}
