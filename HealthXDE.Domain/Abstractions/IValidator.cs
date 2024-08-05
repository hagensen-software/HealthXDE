namespace HealthXDE.Domain.Abstractions;

public interface IValidator<ElementType>
{
    void Validate(ElementType val);
}
