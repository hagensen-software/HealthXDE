namespace HealthXDE.Domain.Patient;

public record PatientId(Guid Id);

internal interface IDeceasedValue;
public record DeceasedBoolean(bool Value) : IDeceasedValue;
public record DeceasedDateTime(DateTimeOffset Value) : IDeceasedValue;

public record Active(bool Value);
public record BirthDate(DateOnly Value);

public interface IMultipleBirthValue;
public record MultipleBirthBoolean(bool Value) : IMultipleBirthValue;
public record MultipleBirthInteger(int Value) : IMultipleBirthValue;