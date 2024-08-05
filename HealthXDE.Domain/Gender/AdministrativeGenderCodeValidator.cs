using HealthXDE.Domain.Abstractions;

namespace HealthXDE.Domain.Gender;

public class AdministrativeGenderCodeValidator : IValidator<AdministrativeGenderCode>
{
    private readonly IValidator<AdministrativeGenderCoding> codingValidator;

    public AdministrativeGenderCodeValidator(IValidator<AdministrativeGenderCoding> codingValidator)
    {
        this.codingValidator = codingValidator;
    }

    public void Validate(AdministrativeGenderCode code)
    {
        var coding = new AdministrativeGenderCoding(null, null, code, null, null);
        codingValidator.Validate(coding);
    }
}
