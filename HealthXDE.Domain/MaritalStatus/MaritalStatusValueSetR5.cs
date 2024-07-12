using HealthXDE.Domain.CodeableConcept;

namespace HealthXDE.Domain.MaritalStatus;

public class MaritalStatusValueSetR5 : ValueSet<MaritalStatusCoding>
{
    public static readonly CodingVersion v3MaritalStatusVersion = new CodingVersion("2.1.0");
    public static readonly CodingSystem v3MaritalStatus = CodingSystem.FromString("http://terminology.hl7.org/CodeSystem/v3-MaritalStatus");
    public static readonly CodingSystem v3NullFlavor = CodingSystem.FromString("http://terminology.hl7.org/CodeSystem/v3-NullFlavor");

    public MaritalStatusValueSetR5()
        : base(false) { }

    /// <summary>
    /// Marriage contract has been declared null and to not have existed
    /// </summary>
    public readonly MaritalStatusCoding Annulled = CreateCode(v3MaritalStatus, "A", "Annulled");
    /// <summary>
    /// Marriage contract has been declared dissolved and inactive
    /// </summary>
    public readonly MaritalStatusCoding Divorced = CreateCode(v3MaritalStatus, "D", "Divorced");
    /// <summary>
    /// Subject to an Interlocutory Decree
    /// </summary>
    public readonly MaritalStatusCoding Interlocutory = CreateCode(v3MaritalStatus, "I", "Interlocutory");
    /// <summary>
    /// Legally Separated
    /// </summary>
    public readonly MaritalStatusCoding LegallySeparated = CreateCode(v3MaritalStatus, "L", "Legally Separated");
    /// <summary>
    /// A current marriage contract is active
    /// </summary>
    public readonly MaritalStatusCoding Married = CreateCode(v3MaritalStatus, "M", "Married");
    /// <summary>
    /// A marriage recognized in some jurisdictions and based on the parties' agreement to consider themselves married and can also be based on documentation of cohabitation.
    /// </summary>
    public readonly MaritalStatusCoding CommonLaw = CreateCode(v3MaritalStatus, "C", "Common Law");
    /// <summary>
    /// More than 1 current spouse
    /// </summary>
    public readonly MaritalStatusCoding Polygamous = CreateCode(v3MaritalStatus, "P", "Polygamous");
    /// <summary>
    /// Person declares that a domestic partner relationship exists.
    /// </summary>
    public readonly MaritalStatusCoding DomesticPartner = CreateCode(v3MaritalStatus, "T", "Domestic partner");
    /// <summary>
    /// Currently not in a marriage contract.
    /// </summary>
    public readonly MaritalStatusCoding Unmarried = CreateCode(v3MaritalStatus, "U", "unmarried");
    /// <summary>
    /// No marriage contract has ever been entered
    /// </summary>
    public readonly MaritalStatusCoding NeverMarried = CreateCode(v3MaritalStatus, "S", "Never Married");
    /// <summary>
    /// The spouse has died
    /// </summary>
    public readonly MaritalStatusCoding Widowed = CreateCode(v3MaritalStatus, "W", "Widowed");
    /// <summary>
    /// A proper value is applicable, but not known.
    /// </summary>
    public readonly MaritalStatusCoding Unknown = CreateCode(v3NullFlavor, "UNK", "unknown");

    private static MaritalStatusCoding CreateCode(CodingSystem system, string code, string display)
    {
        return AddCodingValue(new MaritalStatusCoding(system, v3MaritalStatusVersion, new(code), new(display), null));
    }
}
