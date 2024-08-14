using HealthXDE.Domain.CodeableConcept;

namespace HealthXDE.Domain.MaritalStatus;

public record MaritalStatusBase(CodingList<MaritalStatusCoding> Codings, CodeableConceptText? Text) : ICodeableConcept<MaritalStatusCoding>;
