using System.Collections;

namespace DelegatesOtus.Extensions;

public static class CollectionExtension
{
    public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
    {
        if (collection == null)
        {
            throw new ArgumentException("The collection cannot be null or empty.");
        }
        
        T maxItem = collection.Aggregate<T>((maxItem, element) =>
        {
            var converted = convertToNumber(element);
            var convertedMax = convertToNumber(maxItem);
            
            return converted > convertedMax ? element : maxItem;
        });
        
        return maxItem;
    }
}