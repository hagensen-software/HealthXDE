using HealthXDE.Domain.Identifier;

namespace HealthXDE.Domain.Test.Identifier.ProfiledImplementation;

public class ProfiledIdentifierUseValueSet : IdentifierUseValueSet
{
    internal static readonly string[] sourceArray = ["official"];

    protected override Func<IdentifierUse, bool> GetFilter()
    {
        return c => sourceArray.Contains(c.Code?.Value);
    }
}
