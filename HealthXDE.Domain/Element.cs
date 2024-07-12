using HealthXDE.Domain.Abstractions;

namespace HealthXDE.Domain;

public class Element<ElementBaseType> 
{
    private dynamic? element = null;

    public ElementType Get<ElementType>() where ElementType : ElementBaseType => (ElementType)element!;
    public void Set<ElementType>(ElementType val) where ElementType : ElementBaseType
    {
        if (val is IValidate)
            ((IValidate)val).Validate();
        element = val;
    }
}
