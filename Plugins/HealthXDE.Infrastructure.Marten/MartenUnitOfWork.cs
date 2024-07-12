using HealthXDE.Infrastructure.Abstractions;
using Marten;

namespace HealthXDE.Infrastructure.Marten;

internal class MartenUnitOfWork(IDocumentSession documentSession) : IUnitOfWork
{
    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return documentSession.SaveChangesAsync(cancellationToken);
    }
}
