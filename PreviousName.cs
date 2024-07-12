public record PreviousName : HumanNameBase
{
    public PreviousName(FamilyName family, GivenNameList given, Period? period)
        : base(NameUse.Official, family, given, period)
    {
        family.ThrowExceptionIfEmpty();
        given.ThrowExceptionIfEmpty();
    }

    public NameUse? Use => GetUse();

    public FamilyName? Family => GetFamily();

    public GivenNameList Given => GetGiven();

    public Period? Period => GetPeriod();
}
