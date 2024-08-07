using HealthXDE.Domain.CodeableConcept;

namespace HealthXDE.Domain.Abstractions;

public interface IValidator
{
    void Validate(SimpleCodingBase val);
}
