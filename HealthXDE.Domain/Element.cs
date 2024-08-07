using HealthXDE.Domain.Abstractions;
using HealthXDE.Domain.CodeableConcept;

namespace HealthXDE.Domain;

public class Element<ElementBaseType> 
{
    private dynamic? element = null;
    private IValidator? validator = null;

    public ElementType Get<ElementType>() where ElementType : ElementBaseType => (ElementType)element!;
    public void Set<ElementType>(ElementType val) where ElementType : ElementBaseType
    {
        if (val is SimpleCodingBase coding)
            validator?.Validate(coding);
        element = val;
    }

    public void SetValidator(IValidator validater)
    {
        this.validator = validater;
    }
}
