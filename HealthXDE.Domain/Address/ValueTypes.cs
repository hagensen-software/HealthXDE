namespace HealthXDE.Domain.Address;

public enum AddressUse
{
    Home,
    Work,
    Temp,
    Old,
    Billing
}

public enum AddressType
{
    Postal,
    Physical,
    Both
}

public record AddressText(string text);
public record AddressLine(string Line);
public record AddressCity(string City);
public record AddressDistrict(string District);
public record AddressState(string State);
public record AddressPostalCode(string PostalCode);
public record AddressCountry(string Country);
