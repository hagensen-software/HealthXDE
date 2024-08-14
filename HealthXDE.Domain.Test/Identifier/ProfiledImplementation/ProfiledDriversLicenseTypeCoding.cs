using HealthXDE.Domain.CodeableConcept;
using HealthXDE.Domain.Identifier;

namespace HealthXDE.Domain.Test.Identifier.ProfiledImplementation;

public record ProfiledDriversLicenseTypeCoding : IdentifierTypeCoding
{
    public ProfiledDriversLicenseTypeCoding()
        : base(IdentifierTypeValueSet.hl7CodingSystemV2_0203, null, new Code("DL"), new DisplayValue("Driver's license number"), null) { }
}
