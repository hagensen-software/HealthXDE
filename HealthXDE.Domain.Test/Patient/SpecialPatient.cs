using HealthXDE.Domain.CodeableConcept;
using HealthXDE.Domain.Gender;
using HealthXDE.Domain.Patient;

namespace HealthXDE.Domain.Test.Patient;

internal record SpecialActive(bool Value, string Special) : Active(Value);

internal class SpecialAdministrativeGenderValueSet : AdministrativeGenderValueSetR5
{
    internal static readonly string[] sourceArray = ["male", "female"];

    protected override Func<AdministrativeGenderCoding, bool> GetFilter()
    {
        return c => sourceArray.Contains(c.Code?.Symbol);
    }
}

internal record SpecialAdministrativeGender : AdministrativeGenderCode
{
    private static readonly SpecialAdministrativeGenderValueSet specialAdministrativeGenderValueSet = new();

    public SpecialAdministrativeGender(Code? code)
        : base(code) { }

    public static implicit operator SpecialAdministrativeGender(AdministrativeGenderCoding administrativeGenderCoding)
    {
        return new SpecialAdministrativeGender(administrativeGenderCoding.Code);
    }
}

internal class SpecialPatient : PatientBase
{
    public SpecialPatient(PatientId id) : base(id) { }

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

    public SpecialAdministrativeGender? Gender
    {
        get => GenderElement.Get<SpecialAdministrativeGender?>();
        set => GenderElement.Set(value);
    }

}