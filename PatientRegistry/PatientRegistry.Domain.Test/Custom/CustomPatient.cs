using HealthXDE.Domain.Patient;

namespace PatientRegistry.Domain.Test.Custom;

public class CustomPatient : PatientBase
{
    public CustomPatient(PatientId id, CustomHumanName name)
        : base(id)
    {
        HumanNameElements.AddElement(name);
    }

    public CustomHumanName Name => HumanNameElements.GetElements<CustomHumanName>().First();
}
