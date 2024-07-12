namespace HealthXDE.Domain.Abstractions;

public interface IDomainEventPublisher
{
    Task Publish(IEnumerable<IDomainEvent> events);
}
