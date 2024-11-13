using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace MW.SAXSAY.Shared.Extensions;

public static class Extensions
{
    public static void AddRange<T>(
        this ICollection<T> collection, IEnumerable<T> enumerable) where T : class
    {
        ArgumentNullException.ThrowIfNull(collection);
        ArgumentNullException.ThrowIfNull(enumerable);

        if (collection is BindingList<T> list) 
        {
            // backup event raising value
            bool raiseListChangedEvents = list.RaiseListChangedEvents;
            list.RaiseListChangedEvents = false;

            foreach (var item in enumerable)
                list.Add(item);

            // restore event raising value
            list.RaiseListChangedEvents = raiseListChangedEvents;
            if (raiseListChangedEvents) list.ResetBindings();
        }
        else {
            foreach (var item in enumerable)
                collection.Add(item);
        }
    }
}
