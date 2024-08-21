using HealthXDE.Domain.Abstractions;
using HealthXDE.Domain.DateTime;

namespace HealthXDE.Domain.Address;

public record AddressBase : IValidatable
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

    protected internal AddressUse? GetUse() => addressUse;
    protected internal AddressType? GetAddressType() => addressType;
    protected internal AddressText? GetAddressText() => addressText;
    protected internal AddressLineList GetLines() => addressLineList;
    protected internal AddressCity? GetAddressCity() => addressCity;
    protected internal AddressDistrict? GetAddressDistrict() => addressDistrict;
    protected internal AddressState? GetAddressState() => addressState;
    protected internal AddressPostalCode? GetAddressPostalCode() => addressPostalCode;
    protected internal AddressCountry? GetAddressCountry() => addressCountry;
    protected internal Period? GetPeriod() => period;

    public void Validate(IValidator? validator = null)
    {
        validator?.Validate(this);
    }
}
