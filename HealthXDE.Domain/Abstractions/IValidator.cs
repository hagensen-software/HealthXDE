namespace HealthXDE.Domain.Abstractions;

public interface IValidator
{
    void Validate(IValidatable val);
}
