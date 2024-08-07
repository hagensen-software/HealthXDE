namespace HealthXDE.Domain.Abstractions;

public interface IValidatable
{
    void Validate(IValidator? validator = null);
}
