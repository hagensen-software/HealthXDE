namespace HealthXDE.Domain.Patient;

public record MultipleBirthBase
{
    private readonly IMultipleBirthValue? multipleBirthValue;

    public MultipleBirthBase(MultipleBirthBoolean multipleBirth)
    {
        this.multipleBirthValue = multipleBirth;
    }
    public MultipleBirthBase(MultipleBirthInteger multipleBirth)
    {
        this.multipleBirthValue = multipleBirth;
    }

    protected MultipleBirthBoolean? GetMultipleBirth()
    {
        return multipleBirthValue switch
        {
            MultipleBirthBoolean multipleBirth => multipleBirth,
            MultipleBirthInteger _ => new(true),
            _ => null,
        };
    }

    protected MultipleBirthInteger? GetMultipleBirthInteger()
    {
        return multipleBirthValue switch
        {
            MultipleBirthBoolean _ => throw new InvalidOperationException("Cannot convert MultipleBirthBoolean to MultipleBirthInteger"),
            MultipleBirthInteger multipleBirthInteger => multipleBirthInteger,
            _ => null,
        };
    }
}
