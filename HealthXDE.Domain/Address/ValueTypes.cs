using HealthXDE.Domain.CodeableConcept;

namespace HealthXDE.Domain.Address;

public record AddressUse(Code? Code) : SimpleCodingBase(Code)
{
    public static AddressUseValueSet ValueSet = new();
}

public record AddressType(Code? Code) : SimpleCodingBase(Code)
{
    public static AddressTypeValueSet ValueSet = new();
}

public record AddressText(string text);
public record AddressLine(string Line);
public record AddressCity(string City);
public record AddressDistrict(string District);
public record AddressState(string State);
public record AddressPostalCode(string PostalCode);
public record AddressCountry(string Country);
