using HealthXDE.Domain.Abstractions;
using HealthXDE.Infrastructure.Abstractions;
using MediatR;
using PatientRegistry.Domain.General;
using PatientRegistry.Infrastructure.Abstractions;

namespace GeneralPatientRegistry.Application.RegisterPatient;

public class RegisterPatientCommandHandler(IPatientRepository<Patient> patientRepository,
                                           IDomainEventPublisher publisher,
                                           IUnitOfWork unitOfWork)
    : IRequestHandler<RegisterPatientCommand>
{
    public async Task Handle(RegisterPatientCommand request, CancellationToken cancellationToken)
    {
        var patient = Patient.CreateNewPatient(request.PatientId);

        await patientRepository.Add(patient);

        await publisher.Publish(patient.GetNewDomainEvents());
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
