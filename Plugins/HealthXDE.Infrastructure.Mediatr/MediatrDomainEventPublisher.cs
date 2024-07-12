using HealthXDE.Domain.Abstractions;
using MediatR;

namespace HealthXDE.Infrastructure.Mediatr;

public class MediatrDomainEventPublisher(IPublisher publisher)
    : IDomainEventPublisher
{
    public async Task Publish(IEnumerable<IDomainEvent> events)
    {
        foreach (var domainEvent in events)
            await publisher.Publish(domainEvent);
    }
}
