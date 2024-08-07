using HealthXDE.Domain.CodeableConcept;

namespace HealthXDE.Domain.Gender;

public class AdministrativeGenderValueSet : ValueSet<AdministrativeGenderCoding>
{
    public static readonly CodingSystem hl7AdministrativeGender = CodingSystem.FromString("http://hl7.org/fhir/administrative-gender");

    public AdministrativeGenderValueSet()
        : base(true) { }

    /// <summary>
    /// Male
    /// </summary>
    public readonly AdministrativeGenderCoding Male = CreateCode("male", "Male");
    /// <summary>
    /// Female
    /// </summary>
    public readonly AdministrativeGenderCoding Female = CreateCode("female", "Female");
    /// <summary>
    /// Other
    /// </summary>
    public readonly AdministrativeGenderCoding Other = CreateCode("other", "Other");
    /// <summary>
    /// A proper value is applicable, but not known
    /// </summary>
    public readonly AdministrativeGenderCoding Unknown = CreateCode("unknown", "Unknown");

    private static AdministrativeGenderCoding CreateCode(string code, string display)
    {
        return AddCodingValue(new AdministrativeGenderCoding(hl7AdministrativeGender, null, new(code), new(display), null));
    }
}
