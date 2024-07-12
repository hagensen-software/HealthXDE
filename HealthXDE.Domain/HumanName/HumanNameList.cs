using HealthXDE.Domain.HumanName;
using System.Collections.Immutable;

namespace HealthXDE.Domain;

public class HumanNameList
{
    public HumanNameList()
    {
        this.names = [];
    }

    public HumanNameList(IEnumerable<HumanNameBase> names)
    {
        this.names = names.ToImmutableList();
    }

    public HumanNameList AddName<HumanNameType>(HumanNameType name)
        where HumanNameType : HumanNameBase
    {
        return new(names.Add(name));
    }

    public HumanNameList ChangeName<PrevHumanNameType, HumanNameType>(Func<PrevHumanNameType, HumanNameType> action)
        where PrevHumanNameType : HumanNameBase
        where HumanNameType : HumanNameBase
    {
        return ChangeName(action, _ => true);
    }

    public HumanNameList ChangeName<PrevHumanNameType,HumanNameType>(Func<PrevHumanNameType, HumanNameType> action, Predicate<PrevHumanNameType> match)
        where PrevHumanNameType : HumanNameBase
        where HumanNameType : HumanNameBase
    {
        List<HumanNameBase> newNames = [];

        foreach (var name in names)
        {
            if (name.GetType() == typeof(PrevHumanNameType) && match((PrevHumanNameType)name))
                newNames.Add(action((PrevHumanNameType)name));
            else
                newNames.Add(name);
        }

        return new(newNames);
    }

    public ImmutableList<HumanNameType> GetNames<HumanNameType>()
        where HumanNameType : HumanNameBase
    {
        var result = names.Where(n => n is HumanNameType).Select(n => (HumanNameType)n);
        return result.ToImmutableList();
    }

    private ImmutableList<HumanNameBase> names = [];
}
