using HealthXDE.Domain.Exceptions;

namespace HealthXDE.Domain.CodeableConcept;

public abstract record CodedValue
{
    abstract protected internal bool Matches(CodedValue codedValue);

    internal static string GetCodeSymbol(CodedValue codedValue)
    {
        return codedValue switch
        {
            Code code => code.Symbol,
            CodingBase coding => coding.GetCode()?.Symbol,
            _ => throw new InvalidOperationException("Unknown type of CodedValue")
        } ?? throw new EmptyCodingException();
    }
}
