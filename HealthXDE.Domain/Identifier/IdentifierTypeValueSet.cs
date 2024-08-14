using HealthXDE.Domain.CodeableConcept;

namespace HealthXDE.Domain.Identifier;

public class IdentifierTypeValueSet : ValueSet<IdentifierTypeCoding>
{
    public static readonly CodingSystem hl7CodingSystemV2_0203 = CodingSystem.FromString("http://terminology.hl7.org/CodeSystem/v2-0203");

    public IdentifierTypeValueSet() : base(false) { }

    /// <summary>
    /// Driver's license number
    /// </summary>
    public readonly IdentifierTypeCoding DriversLicenseNumber = CreateCode("DL", "Driver's license number");
    /// <summary>
    /// A unique number assigned to the document affirming that a person is a citizen of the country.
    /// </summary>
    public readonly IdentifierTypeCoding PassportNumber = CreateCode("PPN", "Passport number");
    /// <summary>
    /// Breed Registry Number
    /// </summary>
    public readonly IdentifierTypeCoding BreedRegistryNumber = CreateCode("BRN", "Breed Registry Number");
    /// <summary>
    /// An identifier that is unique to a patient within a set of medical records, not necessarily unique within an application.
    /// </summary>
    public readonly IdentifierTypeCoding MedicalRecordumber = CreateCode("MR", "Medical record number");
    /// <summary>
    /// Microchip Number
    /// </summary>
    public readonly IdentifierTypeCoding MicrochipNumber = CreateCode("MCN", "Microchip Number");
    /// <summary>
    /// Employer number
    /// </summary>
    public readonly IdentifierTypeCoding EmployerNumber = CreateCode("EN", "Employer number");
    /// <summary>
    /// Tax ID number
    /// </summary>
    public readonly IdentifierTypeCoding TaxIdNumber = CreateCode("TAX", "Tax ID number");
    /// <summary>
    /// National Insurance Payor Identifier (Payor)
    /// </summary>
    public readonly IdentifierTypeCoding NationalInsurancePayorIdentifier = CreateCode("NIIP", "National Insurance Payor Identifier (Payor)");
    /// <summary>
    /// A number that is unique to an individual provider, a provider group or an organization within an Assigning Authority.
    /// </summary>
    public readonly IdentifierTypeCoding ProviderNumber = CreateCode("PRN", "Provider number");
    /// <summary>
    /// An identifier that is unique to a medical doctor within the jurisdiction of a licensing board.
    /// </summary>
    public readonly IdentifierTypeCoding MedicalLicenseNumber = CreateCode("MD", "Medical License number");
    /// <summary>
    /// Donor Registration Number
    /// </summary>
    public readonly IdentifierTypeCoding DonorRegistrationNumber = CreateCode("DR", "Donor Registration Number");
    /// <summary>
    /// Accession ID
    /// </summary>
    public readonly IdentifierTypeCoding AccessionId = CreateCode("ACSN", "Accession ID");
    /// <summary>
    /// An identifier assigned to a device using the Unique Device Identification framework as defined by IMDRF (http://imdrf.org).
    /// </summary>
    public readonly IdentifierTypeCoding UniversalDeviceIdentifier = CreateCode("UDI", "Universal Device Identifier");
    /// <summary>
    /// An identifier affixed to an item by the manufacturer when it is first made, where each item has a different identifier.
    /// </summary>
    public readonly IdentifierTypeCoding SerialNumber = CreateCode("SNO", "Serial Number");
    /// <summary>
    /// An identifier issued by a governmental organization to a person to identify the person should they apply for or receive social services and/or benefits
    /// </summary>
    public readonly IdentifierTypeCoding SocialBeneficiaryIdentifier = CreateCode("SB", "Social Beneficiary Identifier");
    /// <summary>
    /// An identifier for a request where the identifier is issued by the person or service making the request.
    /// </summary>
    public readonly IdentifierTypeCoding PlacerIdentifier = CreateCode("PLAC", "Placer Identifier");
    /// <summary>
    /// An identifier for a request where the identifier is issued by the person, or service, that produces the observations or fulfills the request.
    /// </summary>
    public readonly IdentifierTypeCoding FillerIdentifier = CreateCode("FILL", "Filler Identifier");
    /// <summary>
    /// Jurisdictional health number
    /// </summary>
    public readonly IdentifierTypeCoding JurisdictionalHealthNumber = CreateCode("JHN", "Jurisdictional health number");

    private static IdentifierTypeCoding CreateCode(string code, string display)
    {
        return AddCodingValue(new IdentifierTypeCoding(hl7CodingSystemV2_0203, null, new(code), new(display), null));
    }
}
