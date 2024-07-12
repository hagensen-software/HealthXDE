namespace HealthXDE.Domain.Abstractions;

public interface IDomainEvent
{
    Guid Id { get; init; }
}
