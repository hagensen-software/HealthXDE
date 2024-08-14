using HealthXDE.Domain.DateTime;
using HealthXDE.Domain.Identifier;

namespace HealthXDE.Domain.Test.Patient.GeneralImplementation;

internal record GeneralPatientIdentifier : IdentifierBase
{
    public GeneralPatientIdentifier(IdentifierUse? use, IdentifierType? type, IdentifierSystem? system, IdentifierValue? value, Period? period)
        : base(use, type, system, value, period)
    {
    }

    public IdentifierUse? IdentifierUse { get => GetUse(); }
    public IdentifierType? IdentifierType { get => GetIdentifierType(); }
    public IdentifierSystem? System { get => GetSystem(); }
    public IdentifierValue? Value { get => GetValue(); }
    public Period? Period { get => GetPeriod(); }
}
