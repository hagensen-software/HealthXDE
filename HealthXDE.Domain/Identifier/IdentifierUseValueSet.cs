using HealthXDE.Domain.CodeableConcept;
namespace HealthXDE.Domain.Identifier;

public class IdentifierUseValueSet : ValueSet<IdentifierUse>
{
    public IdentifierUseValueSet() : base(true) { }

    /// <summary>
    /// The identifier recommended for display and use in real-world interactions which should be used when such identifier is different from the "official" identifier.
    /// </summary>
    public readonly IdentifierUse Usual = CreateCode("usual");
    /// <summary>
    /// The identifier considered to be most trusted for the identification of this item. Sometimes also known as "primary" and "main".
    /// The determination of "official" is subjective and implementation guides often provide additional guidelines for use.
    /// </summary>
    public readonly IdentifierUse Official = CreateCode("official");
    /// <summary>
    /// A temporary identifier.
    /// </summary>
    public readonly IdentifierUse Temp = CreateCode("temp");
    /// <summary>
    /// An identifier that was assigned in secondary use - it serves to identify the object in a relative context, but cannot be consistently assigned to the same object again in a different context.
    /// </summary>
    public readonly IdentifierUse Secondary = CreateCode("secondary");
    /// <summary>
    /// The identifier id no longer considered valid, but may be relevant for search purposes. E.g. Changes to identifier schemes, account merges, etc.
    /// </summary>
    public readonly IdentifierUse Unknown = CreateCode("old");

    private static IdentifierUse CreateCode(string code)
    {
        return AddCodingValue(new IdentifierUse(new(code)));
    }
}
