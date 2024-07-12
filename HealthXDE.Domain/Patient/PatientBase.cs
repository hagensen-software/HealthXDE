﻿using HealthXDE.Domain.Address;
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
    Element<MaritalStatusBase?> MaritalStatus
);

public class PatientBase : Entity
{
    public PatientId Id { get; }

    protected PatientBase(PatientId id) => Id = id;

    protected ElementList<IdentifierBase> IdentifierElements { get; set; } = new();
    protected Element<Active?> ActiveElement { get; set; } = new();
    protected ElementList<HumanNameBase> HumanNameElements { get; set; } = new();
    protected ElementList<ContactPointBase> TelecomElements { get; set; } = new();
    protected Element<AdministrativeGenderCode?> GenderElement { get; set; } = new();
    protected Element<BirthDate?> BirthDateElement { get; set; } = new();
    protected Element<DeceasedBase?> DeceasedElement { get; set; } = new();
    protected Element<AddressBase?> AddressElement { get; set; } = new();
    protected Element<MaritalStatusBase?> MaritalStatusElement { get; set; } = new();

    protected PatientState GetPatientState() => new(
        IdentifierElements,
        ActiveElement,
        HumanNameElements,
        TelecomElements,
        GenderElement,
        BirthDateElement,
        DeceasedElement,
        AddressElement,
        MaritalStatusElement);
}
