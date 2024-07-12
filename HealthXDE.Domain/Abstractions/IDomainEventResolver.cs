namespace HealthXDE.Domain.Abstractions;

public interface IDomainEventResolver<EntityType> where EntityType : Entity
{
    Task<EntityType> ResolveEvents(IEnumerable<IDomainEvent> events);
}
