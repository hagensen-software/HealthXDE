using HealthXDE.Domain.CodeableConcept;
using HealthXDE.Domain.Gender;
using HealthXDE.Domain.Patient;

namespace HealthXDE.Domain.Test.Patient.ProfiledImplementation;

internal record SpecialActive(bool Value, string Special) : Active(Value);

internal class ProfiledAdministrativeGenderValueSet : AdministrativeGenderValueSet
{
    internal static readonly string[] sourceArray = ["male", "female"];

    protected override Func<AdministrativeGenderCoding, bool> GetFilter()
    {
        return c => sourceArray.Contains(c.Code?.Value);
    }
}

internal record ProfiledAdministrativeGender : AdministrativeGenderCode
{
    private static readonly ProfiledAdministrativeGenderValueSet specialAdministrativeGenderValueSet = new();

    public ProfiledAdministrativeGender(Code? code)
        : base(code) { }

    public static implicit operator ProfiledAdministrativeGender(AdministrativeGenderCoding administrativeGenderCoding)
    {
        return new ProfiledAdministrativeGender(administrativeGenderCoding.Code);
    }
}

internal class ProfiledPatient : PatientBase
{
    public ProfiledPatient(PatientId id) : base(id) { }

    public SpecialActive? Active
    {
        get => ActiveElement.Get<SpecialActive?>();
        set => ActiveElement.Set(value);
    }

    public ProfiledIdentifier? Identifier
    {
        get => IdentifierElements.GetElements<ProfiledIdentifier>().FirstOrDefault();
        set
        {
            IdentifierElements.Clear();
            if (value != null)
                IdentifierElements.AddElement(value);
        }
    }

    public ProfiledAdministrativeGender? Gender
    {
        get => GenderElement.Get<ProfiledAdministrativeGender?>();
        set => GenderElement.Set(value);
    }

}