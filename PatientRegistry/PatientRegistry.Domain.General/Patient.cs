using HealthXDE.Domain.Gender;
using HealthXDE.Domain.Patient;
using PatientRegistry.Domain.General.Events;

namespace PatientRegistry.Domain.General;

public class Patient : PatientBase
{
    internal Patient(PatientId id) : base(id) {}

    public static Patient CreateNewPatient(PatientId patientId)
    {
        var ev = new PatientRegistered(Guid.NewGuid(), patientId);

        var patient = new PatientEventResolver()
            .Apply(ev);

        patient.AddNewEvent(ev);

        return patient;
    }

    public void AddName<HumanNameType>(HumanNameType name) where HumanNameType : HumanName
    {
        var ev = new PatientNameAdded<HumanNameType>(Guid.NewGuid(), Id, name);

        new PatientEventResolver(this).Apply(AddNewEvent(ev));
    }

    public IReadOnlyList<HumanNameType> GetNames<HumanNameType>() where HumanNameType : HumanName
    {
        return HumanNameElements.GetElements<HumanNameType>();
    }

    public AdministrativeGenderCode? Gender
    {
        get => GenderElement.Get<AdministrativeGenderCode?>();
    }

    public void ChangeGender(AdministrativeGenderCoding gender)
    {
        var ev = new PatientGenderChanged(Guid.NewGuid(), Id, gender);

        new PatientEventResolver(this).Apply(AddNewEvent(ev));
    }

    internal PatientState GetState() => GetPatientState();
}
