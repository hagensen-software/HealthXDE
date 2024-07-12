using CustomPatientRegistry.Application.Abstractions;
using CustomPatientRegistry.Domain;
using HealthXDE.Domain.Abstractions;
using HealthXDE.Infrastructure.Abstractions;
using MediatR;

namespace CustomPatientRegistry.Application.RegisterPatient;

public class RegisterPatientCommandHandler(IPatientRepository patientRepository,
                                           IDomainEventPublisher publisher,
                                           IUnitOfWork unitOfWork)
    : IRequestHandler<RegisterPatientCommand>
{
    public async Task Handle(RegisterPatientCommand request, CancellationToken cancellationToken)
    {
        var patient = Patient.CreateNewPatient(request.PatientId, request.Name);

        await patientRepository.Add(patient);

        await publisher.Publish(patient.GetNewDomainEvents());
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
