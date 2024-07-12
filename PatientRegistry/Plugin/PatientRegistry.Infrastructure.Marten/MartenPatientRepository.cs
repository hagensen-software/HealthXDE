using HealthXDE.Domain.Abstractions;
using HealthXDE.Domain.Patient;
using HealthXDE.Infrastructure.Abstractions;
using Marten;
using PatientRegistry.Infrastructure.Abstractions;

namespace PatientRegistry.Infrastructure.Marten;

public class MartenPatientRepository<PatientType>(IDocumentSession documentSession,
                                                  IDomainEventResolver<PatientType> eventResolver,
                                                  IDomainEventPublisher eventPublisher,
                                                  IUnitOfWork unitOfWork)
    : IPatientRepository<PatientType> where PatientType : PatientBase
{
    private readonly IDomainEventResolver<PatientType> eventResolver = eventResolver;

    public async Task<PatientType> Get(PatientId patientId)
    {
        var events = await documentSession.Events.FetchStreamAsync(patientId.Id);
        return await eventResolver.ResolveEvents(events.Select(ev => (IDomainEvent)ev.Data));
    }

    public Task Add(PatientType patient)
    {
        var events = patient.GetNewDomainEvents();
        eventPublisher.Publish(events);
        documentSession.Events.StartStream<PatientType>(patient.Id.Id, events);
        patient.ClearNewEvents();

        return Task.CompletedTask;
    }

    public Task Update(PatientType patient)
    {
        var events = patient.GetNewDomainEvents();
        eventPublisher.Publish(events);
        documentSession.Events.Append(patient.Id.Id, events);
        patient.ClearNewEvents();

        return Task.CompletedTask;
    }

    public Task Remove(PatientType patient)
    {
        throw new NotImplementedException();
    }
}
