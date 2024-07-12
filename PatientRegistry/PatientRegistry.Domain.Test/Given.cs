using HealthXDE.Domain.HumanName;
using HealthXDE.Domain.Patient;
using PatientRegistry.Domain.General;
using PatientRegistry.Domain.Test.Custom;

namespace PatientRegistry.Domain.Test;


internal static class Given
{
    internal static Patient GeneralPatient()
    {
        var patient = Patient.CreateNewPatient(new PatientId(Guid.NewGuid()));
        patient.ClearNewEvents();
        return patient;
    }

    internal static HumanName GeneralHumanName()
        => new(null, null, null, null);

    internal static FamilyName FamilyName()
        => new("Doe");

    internal static GivenNameList GivenName() => new([new("John")]);

    internal static CustomHumanName CustomHumanName()
        => new(CustomNameUse.Official, new("Doe"), new([new("John")]));
}
