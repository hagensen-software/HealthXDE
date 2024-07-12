using HealthXDE.Domain.Identifier;

namespace HealthXDE.Domain.Test.Patient;

internal record ProfiledIdentifier : IdentifierBase
{
    public ProfiledIdentifier(IdentifierValue value)
        : base(IdentifierUse.Official, null, IdentifierSystem.FromString("http://hl7.org/fhir/sid/passport-DNK"), value, null) { }

    public IdentifierValue Value
    {
        get => GetValue() ?? throw new InvalidOperationException("Invalid null value encountered for ProfiledIdentifier");
    }
}
