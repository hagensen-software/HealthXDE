using HealthXDE.Domain.Abstractions;
using HealthXDE.Domain.CodeableConcept;

namespace HealthXDE.Domain.Identifier;

public record IdentifierTypeCoding : CodingBase
{
    public IdentifierTypeCoding(CodingSystem? system, CodingVersion? version, Code code, DisplayValue? display, UserSelected? userSelected)
        : base(system, version, code, display, userSelected) { }

    public Code Code => GetCode()!;
}

public record IdentifierType(CodingList<IdentifierTypeCoding> Codings, CodeableConceptText? Text) : ICodeableConcept<IdentifierTypeCoding>, IValidatable
{
    public void Validate(IValidator? validator = null)
    {
        foreach (CodingBase coding in Codings.GetCodings<IdentifierTypeCoding>())
            coding.Validate(validator);
    }
}
