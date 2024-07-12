using HealthXDE.Domain.Exceptions;

namespace HealthXDE.Domain.DateTime;

public record Period
{
    public Period(DateTimeOffset? start, DateTimeOffset? end)
    {
        if (start != null && end != null && start > end)
            throw new InvalidPeriodException((DateTimeOffset)start, (DateTimeOffset)end!);

        Start = start;
        End = end;
    }

    public DateTimeOffset? Start { get; }
    public DateTimeOffset? End { get; }

    public bool Overlaps(DateTimeOffset date)
    {
        var start1 = Start ?? DateTimeOffset.MinValue;
        var end1 = End ?? DateTimeOffset.MaxValue;

        return date >= start1 && date <= end1;
    }

    public bool Overlaps(Period period)
    {
        var start1 = Start ?? DateTimeOffset.MinValue;
        var end1 = End ?? DateTimeOffset.MaxValue;
        var start2 = period?.Start ?? DateTimeOffset.MinValue;
        var end2 = period?.End ?? DateTimeOffset.MaxValue;

        return start1 >= start2 && start1 <= end2 ||
               end1 >= start2 && end1 <= end2 ||
               start2 >= start1 && start2 <= end1 ||
               end2 >= start1 && end2 <= end1;
    }

    public void ThrowExceptionIfEmpty()
    {
        if (Start == null && End == null)
            throw new EmptyPeriodException();
    }

    public void ThowExceptionIfNoEndDate()
    {
        if (End == null)
            throw new PeriodNotEndedException();
    }
}
