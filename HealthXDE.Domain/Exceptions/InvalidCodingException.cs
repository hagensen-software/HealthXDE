namespace HealthXDE.Domain.Exceptions;

public class InvalidCodingException : ApplicationException
{
    public InvalidCodingException(string message)
        : base(message) { }
}
