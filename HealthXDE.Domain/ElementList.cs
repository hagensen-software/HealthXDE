namespace HealthXDE.Domain;

public class ElementList<ElementBaseType> where ElementBaseType : class
{
    private List<ElementBaseType> elements = [];

    public ElementList() { }
    public ElementList(params ElementBaseType?[] elements)
    {
        this.elements = new List<ElementBaseType>(elements.Where(e => e != null).Cast<ElementBaseType>());
    }

    public ElementList<ElementBaseType> AddElement<ElementType>(ElementType name)
        where ElementType : ElementBaseType
    {
        elements.Add(name);
        return this;
    }

    public ElementList<ElementBaseType> ChangeElement<PrevElementType, ElementType>(Func<PrevElementType, ElementType> action)
        where PrevElementType : ElementBaseType
        where ElementType : ElementBaseType
    {
        if (elements.Where(n => n is ElementType).Count() > 1)
            throw new InvalidOperationException("ChangeElement applied on ElementList with multiple elements of the given type");

        return ChangeElements(action, _ => true);
    }

    public ElementList<ElementBaseType> ChangeElements<PrevElementType, ElementType>(Func<PrevElementType, ElementType> action, Predicate<PrevElementType> match)
        where PrevElementType : ElementBaseType
        where ElementType : ElementBaseType
    {
        List<ElementBaseType> newElements = [];

        foreach (var element in elements)
        {
            if (element.GetType() == typeof(PrevElementType) && match((PrevElementType)element))
                newElements.Add(action((PrevElementType)element));
            else
                newElements.Add(element);
        }

        elements = newElements;

        return this;
    }

    public ElementList<ElementBaseType> Clear()
    {
        elements.Clear();
        return this;
    }

    public IReadOnlyList<ElementType> GetElements<ElementType>() where ElementType : ElementBaseType
    {
        var result = elements.Where(n => n is ElementType).Select(n => (ElementType)n);
        return result.ToList();
    }
}
