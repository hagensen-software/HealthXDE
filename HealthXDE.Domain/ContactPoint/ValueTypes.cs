using HealthXDE.Domain.Exceptions;

namespace HealthXDE.Domain.ContactPoint;

public enum ContactPointUse
{
    Home,
    Work,
    Temp,
    Old,
    Mobile
}

public enum ContactPointSystem
{
    Phone,
    Fax,
    Email,
    Pager,
    Url,
    Sms,
    Other
}

public record ContactPointRank(uint Rank) { }

public record ContactPointValue(string Value)
{
    public void ThrowExceptionIfEmpty()
    {
        if (string.IsNullOrWhiteSpace(Value)) throw new EmptyContactPointValueException();
    }
}
