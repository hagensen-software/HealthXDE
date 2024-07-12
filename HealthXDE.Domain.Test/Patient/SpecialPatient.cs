using HealthXDE.Domain.Gender;
using HealthXDE.Domain.Patient;

namespace HealthXDE.Domain.Test.Patient;

internal record SpecialActive(bool Value, string Special) : Active(Value);

internal class SpecialAdministrativeGenderValueSet : AdministrativeGenderValueSetR5
{
}

internal record SpecialAdministrativeGender : AdministrativeGenderCode
{
    static SpecialAdministrativeGender()
    {
        AdministrativeGenderValueSet.OverrideR5ValueSet(new SpecialAdministrativeGenderValueSet());
    }

    public SpecialAdministrativeGender(string Symbol)
        : base(Symbol) { }

    public static implicit operator SpecialAdministrativeGender(AdministrativeGenderCoding administrativeGenderCoding)
    {
        return new SpecialAdministrativeGender(((AdministrativeGenderCode)administrativeGenderCoding).Symbol);
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