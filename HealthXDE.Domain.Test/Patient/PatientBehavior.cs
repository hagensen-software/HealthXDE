using HealthXDE.Domain.ContactPoint;
using HealthXDE.Domain.Exceptions;
using HealthXDE.Domain.Gender;
using HealthXDE.Domain.Identifier;
using HealthXDE.Domain.Patient;
using HealthXDE.Domain.Test.Patient.GeneralImplementation;
using HealthXDE.Domain.Test.Patient.ProfiledImplementation;

namespace HealthXDE.Domain.Test.Patient;

public class PatientBehavior
{
    [Fact]
    public void Given_AGeneralPatient_Then_NoIdentifiersAreAssigned()
    {
        var patientId = new PatientId(Guid.NewGuid());
        var patient = new GeneralPatient(patientId);

        Assert.Empty(patient.Identifiers);
    }

    [Fact]
    public void Given_AGeneralPatient_WhenIdentifierIsAssigned_Then_IdentifierIsContained()
    {
        var patientId = new PatientId(Guid.NewGuid());
        var patient = new GeneralPatient(patientId);

        patient.AddPatientIdentifier(new GeneralPatientIdentifier(IdentifierUse.ValueSet.Official, null, IdentifierSystem.FromString("http://hl7.org/fhir/sid/passport-DNK"), new("123456789"), null));

        Assert.Collection(patient.Identifiers, i =>
            {
                Assert.Equal(IdentifierUse.ValueSet.Official, i.IdentifierUse);
                Assert.Equal(new IdentifierValue("123456789"), i.Value);
            });
    }

    [Fact]
    public void Given_ASpecialPatient_Then_NoIdentifierIsAssigned()
    {
        var patientId = new PatientId(Guid.NewGuid());
        var patient = new ProfiledPatient(patientId);

        Assert.Null(patient.Identifier);
    }

    [Fact]
    public void Given_ASpecialPatient_When_ProfiledIdentifierIsAssigned_Then_IdentifierIsSet()
    {
        var patientId = new PatientId(Guid.NewGuid());
        var patient = new ProfiledPatient(patientId)
        {
            Identifier = new ProfiledIdentifier(new("123456789"))
        };

        Assert.Equal(new ProfiledIdentifier(new("123456789")), patient.Identifier);
    }

    [Fact]
    public void Given_AGeneralPatient_Then_ActiveIsNotSet()
    {
        var patientId = new PatientId(Guid.NewGuid());
        var patient = new GeneralPatient(patientId);

        Assert.Null(patient.Active);
    }

    [Fact]
    public void Given_AGeneralPatient_When_ActiveIsAssigned_Then_ActiveIsSet()
    {
        var patientId = new PatientId(Guid.NewGuid());
        var patient = new GeneralPatient(patientId)
        {
            Active = new(true)
        };

        Assert.Equal(new(true), patient.Active);
    }

    [Fact]
    public void Given_ASpecialPatient_Then_ActiveIsNotSet()
    {
        var patientId = new PatientId(Guid.NewGuid());
        var patient = new ProfiledPatient(patientId);

        Assert.Null(patient.Active);
    }

    [Fact]
    public void Given_ASpecialPatient_When_SpecialActiveIsAssigned_Then_ActiveIsSet()
    {
        var patientId = new PatientId(Guid.NewGuid());
        var patient = new ProfiledPatient(patientId)
        {
            Active = new(true, "test")
        };

        Assert.Equal(new(true, "test"), patient.Active);
    }

    [Fact]
    public void Given_AGeneralPatient_Then_NoTelecomIsAssigned()
    {
        var patientId = new PatientId(Guid.NewGuid());
        var patient = new GeneralPatient(patientId);

        Assert.Empty(patient.Telecom);
    }

    [Fact]
    public void Given_AGeneralPatient_WhenTelecomIsAssigned_Then_TelecomIsContained()
    {
        var patientId = new PatientId(Guid.NewGuid());
        var patient = new GeneralPatient(patientId);

        patient.AddTelecom(new GeneralContactPoint(ContactPointSystem.Phone, new("12345678"), ContactPointUse.Mobile, null, null));

        Assert.Collection(patient.Telecom, t =>
        {
            Assert.Equal(ContactPointSystem.Phone, t.System);
            Assert.Equal(new("12345678"), t.Value);
            Assert.Equal(ContactPointUse.Mobile, t.Use);
        });
    }

    [Fact]
    public void Given_AGeneralPatient_Then_GenderIsNotSet()
    {
        var patientId = new PatientId(Guid.NewGuid());
        var patient = new GeneralPatient(patientId);

        Assert.Null(patient.Gender);
    }

    [Fact]
    public void Given_AGeneralPatient_When_GenderIsAssigned_Then_GenderIsSet()
    {
        var patientId = new PatientId(Guid.NewGuid());
        var patient = new GeneralPatient(patientId)
        {
            Gender = AdministrativeGenderCoding.ValueSet.Male
        };

        Assert.Equal(AdministrativeGenderCoding.ValueSet.Male, patient.Gender);
    }

    [Fact]
    public void Given_AGeneralPatient_When_InvalidGenderIsAssigned_Then_ExceptionIsThrown()
    {
        var patientId = new PatientId(Guid.NewGuid());

        Assert.Throws<InvalidCodingException>(() =>
            new GeneralPatient(patientId)
            {
                Gender = new AdministrativeGenderCode(new("someInvalidCode"))
            });
    }

    [Fact]
    public void Given_ASpecialPatient_Then_GenderIsNotSet()
    {
        var patientId = new PatientId(Guid.NewGuid());
        var patient = new ProfiledPatient(patientId);

        Assert.Null(patient.Gender);
    }


    [Fact]
    public void Given_ASpecialPatient_When_GenderIsAssigned_Then_GenderIsSet()
    {
        var male = AdministrativeGenderCoding.ValueSet.Male;

        var patientId = new PatientId(Guid.NewGuid());
        var patient = new ProfiledPatient(patientId)
        {
            Gender = male
        };

        Assert.Equal(male, patient.Gender);
    }
}