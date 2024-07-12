using System.Collections.Immutable;
using HealthXDE.Domain.Abstractions;

namespace HealthXDE.Domain;

public abstract class Entity
{
    private readonly List<IDomainEvent> domainEvents = [];

    protected DomainEventType AddNewEvent<DomainEventType>(DomainEventType domainEvent)
        where DomainEventType : IDomainEvent
    { 
        domainEvents.Add(domainEvent);

        return domainEvent;
    }

    public void ClearNewEvents() => domainEvents.Clear();

    public IImmutableList<IDomainEvent> GetNewDomainEvents() => domainEvents.ToImmutableList();
}
