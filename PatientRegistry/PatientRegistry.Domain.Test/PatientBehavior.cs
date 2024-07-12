using HealthXDE.Domain.Patient;
using PatientRegistry.Domain.General;
using PatientRegistry.Domain.General.Events;

namespace PatientRegistry.Domain.Test;

public class PatientBehavior
{
    [Fact]
    public void When_PatientIsCreated_And_IdIsProvided_Then_PatientHasTheGivenId_And_PreparesAPatientRegisteredEvent()
    {
        var patientId = new PatientId(Guid.NewGuid());

        var patient = Patient.CreateNewPatient(patientId);

        Assert.Equal(patientId, patient.Id);
        Assert.Collection(patient.GetNewDomainEvents(), ev => Assert.IsType<PatientRegistered>(ev));
    }

    [Fact]
    public void Given_AMinimalPatient_When_AValidNameIsAdded_Then_PatientHasTheName_And_PreparesAPatientNameAddedEvent()
    {
        var patient = Given.GeneralPatient();
        var name = Given.GeneralHumanName();

        patient.AddName(name);

        Assert.Equal(name, patient.GetNames<HumanName>().First());
        Assert.Collection(patient.GetNewDomainEvents(), ev => Assert.IsType<PatientNameAdded<HumanName>>(ev));
    }
}