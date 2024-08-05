using HealthXDE.Domain.Abstractions;

namespace HealthXDE.Domain;

public class Element<ElementBaseType> 
{
    private dynamic? element = null;
    private dynamic? validator = null;

    public ElementType Get<ElementType>() where ElementType : ElementBaseType => (ElementType)element!;
    public void Set<ElementType>(ElementType val) where ElementType : ElementBaseType
    {
        validator?.Validate(val);
        element = val;
    }

    public void SetValidator<ElementType>(IValidator<ElementType> validater) //where ElementType : ElementBaseType
    {
        this.validator = validater;
    }
}
