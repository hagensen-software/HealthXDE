using HealthXDE.Domain.Exceptions;

namespace HealthXDE.Domain.HumanName;

public enum NameUse
{
    Usual,
    Official,
    Temp,
    Nickname,
    Anonymous,
    Old,
    Maiden
}

public record GivenName(string Name)
{
    public void ThrowExceptionIfEmpty()
    {
        if (string.IsNullOrWhiteSpace(Name)) throw new EmptyGivenNameException();
    }
}

public record FamilyName(string Name)
{
    public void ThrowExceptionIfEmpty()
    {
        if (string.IsNullOrWhiteSpace(Name)) throw new EmptyFamilyNameException();
    }
}
