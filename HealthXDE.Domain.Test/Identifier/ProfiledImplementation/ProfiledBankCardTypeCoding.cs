using HealthXDE.Domain.CodeableConcept;
using HealthXDE.Domain.Identifier;

namespace HealthXDE.Domain.Test.Identifier.ProfiledImplementation;

public record ProfiledBankCardTypeCoding : IdentifierTypeCoding
{
    public ProfiledBankCardTypeCoding()
        : base(IdentifierTypeValueSet.hl7CodingSystemV2_0203, null, new Code("BC"), new DisplayValue("Bank Card Number"), null) { }
}
