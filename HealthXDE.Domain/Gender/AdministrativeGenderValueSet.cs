using HealthXDE.Domain.CodeableConcept;

namespace HealthXDE.Domain.Gender;

public class AdministrativeGenderValueSet : ValueSetCollection<AdministrativeGenderCoding>
{
    public static AdministrativeGenderValueSetR4 R4 = new();
    public static AdministrativeGenderValueSetR5 R5 = new();

    public AdministrativeGenderValueSet()
        : base(R4, R5) { }
}
