namespace HealthXDE.Domain.CodeableConcept;

public interface ICodeableConcept
{
    CodingList Codings { get; init; }
    CodeableConceptText? Text { get; init; }
}
