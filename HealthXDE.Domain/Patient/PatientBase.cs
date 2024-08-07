using HealthXDE.Domain.Address;
using HealthXDE.Domain.ContactPoint;
using HealthXDE.Domain.Gender;
using HealthXDE.Domain.HumanName;
using HealthXDE.Domain.Identifier;
using HealthXDE.Domain.MaritalStatus;

namespace HealthXDE.Domain.Patient;

public record PatientState(
    ElementList<IdentifierBase> IdentifierElements,
    Element<Active?> ActiveElement,
    ElementList<HumanNameBase> HumanNameElements,
    ElementList<ContactPointBase> TelecomElements,
    Element<AdministrativeGenderCode?> GenderElement,
    Element<BirthDate?> BirthDateElement,
    Element<DeceasedBase?> DeceasedElement,
    Element<AddressBase?> AddressElement,
    Element<MaritalStatusBase?> MaritalStatus,
    Element<MultipleBirthBase?> MultipleBirth
);

public class PatientBase : Entity
{
    public PatientId Id { get; }

    protected PatientBase(PatientId id)
    {
        GenderElement.SetValidator(AdministrativeGenderCoding.ValueSet);

        Id = id;
    }

    protected ElementList<IdentifierBase> IdentifierElements { get; set; } = new();
    protected Element<Active?> ActiveElement { get; set; } = new();
    protected ElementList<HumanNameBase> NameElements { get; set; } = new();
    protected ElementList<ContactPointBase> TelecomElements { get; set; } = new();
    protected Element<AdministrativeGenderCode?> GenderElement { get; set; } = new();
    protected Element<BirthDate?> BirthDateElement { get; set; } = new();
    protected Element<DeceasedBase?> DeceasedElement { get; set; } = new();
    protected Element<AddressBase?> AddressElement { get; set; } = new();
    protected Element<MaritalStatusBase?> MaritalStatusElement { get; set; } = new();
    protected Element<MultipleBirthBase?> MultipleBirthElement { get; set; } = new();

    protected PatientState GetPatientState() => new(
        IdentifierElements,
        ActiveElement,
        NameElements,
        TelecomElements,
        GenderElement,
        BirthDateElement,
        DeceasedElement,
        AddressElement,
        MaritalStatusElement,
        MultipleBirthElement);
}
