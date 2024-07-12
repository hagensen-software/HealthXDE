namespace HealthXDE.Domain.Exceptions;

public class InvalidPeriodException : ApplicationException
{
    public InvalidPeriodException(DateTimeOffset Start, DateTimeOffset End)
    {
        this.Start = Start;
        this.End = End;
    }

    public DateTimeOffset Start { get; }
    public DateTimeOffset End { get; }
}
