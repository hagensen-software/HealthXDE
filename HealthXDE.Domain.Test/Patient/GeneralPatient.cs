using HealthXDE.Domain.Gender;
using HealthXDE.Domain.Patient;

namespace HealthXDE.Domain.Test.Patient;

internal class GeneralPatient : PatientBase
{
    public GeneralPatient(PatientId id) : base(id)
    {
        GenderElement.SetValidator(new AdministrativeGenderValueSetR5());
    }

    public Active? Active
    {
        get => ActiveElement.Get<Active?>();
        set => ActiveElement.Set(value);
    }

    public void AddPatientIdentifier(GeneralPatientIdentifier identifier) => IdentifierElements.AddElement(identifier);

    public IReadOnlyList<GeneralPatientIdentifier> Identifiers => IdentifierElements.GetElements<GeneralPatientIdentifier>();

    public void AddTelecom(GeneralContactPoint telecom) => TelecomElements.AddElement(telecom);
    public IReadOnlyList<GeneralContactPoint> Telecom => TelecomElements.GetElements<GeneralContactPoint>();

    public AdministrativeGenderCode? Gender
    {
        get => GenderElement.Get<AdministrativeGenderCode?>();
        set => GenderElement.Set(value);
    }
}
