using HealthXDE.Domain.CodeableConcept;
using HealthXDE.Domain.Identifier;
using System.Collections.Immutable;

namespace HealthXDE.Domain.Test.Identifier.ProfiledImplementation;

public class ProfiledIdentifierTypeValueSet : IdentifierTypeValueSet
{
    internal static readonly string[] sourceArray = ["DL"];

    protected override Func<IdentifierTypeCoding, bool> GetFilter()
    {
        return c => sourceArray.Contains(c.Code.Value);
    }

    protected override ImmutableList<IdentifierTypeCoding> GetExtensions()
    {
        return [new IdentifierTypeCoding(IdentifierTypeValueSet.hl7CodingSystemV2_0203, null, new Code("BC"), new DisplayValue("Bank Card Number"), null)];
    }
}
