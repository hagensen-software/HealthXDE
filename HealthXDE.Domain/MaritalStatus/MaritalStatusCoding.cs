using HealthXDE.Domain.CodeableConcept;

namespace HealthXDE.Domain.MaritalStatus;

public record MaritalStatusCoding : CodingBase
{
    public static readonly MaritalStatusValueSet ValueSets = new();

    public MaritalStatusCoding(CodingSystem? system, CodingVersion? version, Code? code, DisplayValue? display, UserSelected? userSelected)
        : base(system, version, code, display, userSelected) { }

    public MaritalStatusCoding(CodingBase codingBase)
        : base(
            codingBase.GetSystem(),
            codingBase.GetVersion(),
            codingBase.GetCode(),
            codingBase.GetDisplay(),
            codingBase.GetUserSelected()) { }
}
