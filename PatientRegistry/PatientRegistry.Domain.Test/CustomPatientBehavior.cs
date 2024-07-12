using HealthXDE.Domain.Patient;
using PatientRegistry.Domain.Test.Custom;

namespace PatientRegistry.Domain.Test;

public class CustomPatientBehavior
{
    [Fact]
    public void When_PatientIsCreated_And_IdAndNameIsProvided_Then_PatientHasTheGivenIdAndName()
    {
        var patientId = new PatientId(Guid.NewGuid());
        var name = Given.CustomHumanName();

        var patient = new CustomPatient(patientId, name);

        Assert.Equal(patientId, patient.Id);
        Assert.Equal(name, patient.Name);
    }
}
