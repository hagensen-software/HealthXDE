using HealthXDE.Domain.CodeableConcept;

namespace HealthXDE.Domain.MaritalStatus;

public record MaritalStatusBase(CodingList Codings, CodeableConceptText? Text) : ICodeableConcept;
