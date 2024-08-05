using HealthXDE.Domain.Patient;

namespace PatientRegistry.Domain.Test.Custom;

public class CustomPatient : PatientBase
{
    public CustomPatient(PatientId id, CustomHumanName name)
        : base(id)
    {
        NameElements.AddElement(name);
    }

    public CustomHumanName Name => NameElements.GetElements<CustomHumanName>().First();
}
