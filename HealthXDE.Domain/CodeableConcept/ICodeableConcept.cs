namespace HealthXDE.Domain.CodeableConcept;

public interface ICodeableConcept<CodingBaseType> where CodingBaseType : CodingBase
{
    CodingList<CodingBaseType> Codings { get; init; }
    CodeableConceptText? Text { get; init; }
}
