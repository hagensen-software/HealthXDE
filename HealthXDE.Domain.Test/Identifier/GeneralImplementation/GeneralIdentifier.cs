﻿using HealthXDE.Domain.DateTime;
using HealthXDE.Domain.Identifier;

namespace HealthXDE.Domain.Test.Identifier.GeneralImplementation;

public record GeneralIdentifier : IdentifierBase
{
    public GeneralIdentifier(IdentifierUse? use, IdentifierType? type, IdentifierSystem? system, IdentifierValue? value, Period? period)
        : base(use, type, system, value, period) { }

    public IdentifierUse? Use => GetUse();
    public IdentifierType? Type => GetIdentifierType();
    public IdentifierSystem? System => GetSystem();
    public IdentifierValue? Value => GetValue();
    public Period? Period => GetPeriod();
}
