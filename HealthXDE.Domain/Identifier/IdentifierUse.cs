using HealthXDE.Domain.CodeableConcept;

namespace HealthXDE.Domain.Identifier;

public record IdentifierUse(Code? Code) : SimpleCodingBase(Code)
{
    public static IdentifierUseValueSet ValueSet = new IdentifierUseValueSet();
}
