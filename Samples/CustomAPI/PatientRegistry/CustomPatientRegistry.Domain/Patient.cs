using CustomPatientRegistry.Domain.Events;
using HealthXDE.Domain.DateTime;
using HealthXDE.Domain.Patient;

namespace CustomPatientRegistry.Domain;

public class Patient : PatientBase
{
    internal Patient(PatientId id, OfficialName name)
        : base(id)
    {
        Name = name;
    }

    public static Patient CreateNewPatient(PatientId patientId, OfficialName name)
    {
        var ev = new PatientRegistered(Guid.NewGuid(), patientId, name);

        var patient = new PatientEventResolver().Apply(ev);

        patient.AddNewEvent(ev);

        return patient;
    }

    public void ChangePatientName(OfficialName newName)
    {
        if (newName.Start == null)
            throw new ArgumentException("No start date provided for ChangePatientName", nameof(newName));

        var overlappingNames = NameElements.GetElements<PreviousName>().Where(n => n.Period.Overlaps(new Period(newName.Start, null)));
        if (overlappingNames.Count() > 1)
            throw new InvalidOperationException("Cannot change patient name when it overlaps multiple previous names in time");

        var eventResolver = new PatientEventResolver(this);
        eventResolver
            .Apply(AddNewEvent(new PatientNameChanged(Guid.NewGuid(), newName)));
    }

    public OfficialName Name
    {
        get => NameElements.GetElements<OfficialName>().First();
        internal set
        {
            var start = value.Start ?? throw new InvalidOperationException("No start date provided for ChangePatientName");

            NameElements
                .ChangeElement((OfficialName officialName) => new PreviousName(officialName, start))
                .AddElement(value);
        }
    }

    public IReadOnlyList<PreviousName> PreviousNames => NameElements.GetElements<PreviousName>();
}
