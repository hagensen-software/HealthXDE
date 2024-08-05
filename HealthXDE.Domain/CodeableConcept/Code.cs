using HealthXDE.Domain.Exceptions;

namespace HealthXDE.Domain.CodeableConcept;

public record Code(string Symbol) : CodedValue
{
    public void ThrowIfEmpty()
    {
        if (string.IsNullOrWhiteSpace(Symbol))
            throw new EmptyCodingException();
    }

    protected internal override bool Matches(CodedValue codedValue)
    {
        return Symbol == CodedValue.GetCodeSymbol(codedValue);
    }
}