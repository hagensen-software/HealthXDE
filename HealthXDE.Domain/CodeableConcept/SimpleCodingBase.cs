using HealthXDE.Domain.Abstractions;
using HealthXDE.Domain.Exceptions;

namespace HealthXDE.Domain.CodeableConcept;

public record SimpleCodingBase : IValidatable
{
    private readonly Code? code;

    public SimpleCodingBase(Code? code)
    {
        this.code = code;
    }
    protected internal void ThrowIfEmpty()
    {
        if (code is null)
            throw new EmptyCodingException();
    }

    protected internal Code? GetCode() => code;

    protected internal virtual bool Matches(SimpleCodingBase codedValue)
    {
        this.ThrowIfEmpty();
        codedValue.ThrowIfEmpty();

        return code!.Symbol == codedValue.code!.Symbol;
    }

    public void Validate(IValidator? validator) => validator?.Validate(this);
}
