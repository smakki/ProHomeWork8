namespace ProHomeWork8;

public static class EnumerableExtensions
{
    public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber)
        where T : class
    {
        ArgumentNullException.ThrowIfNull(collection);

        using var enumerator = collection.GetEnumerator();

        if (!enumerator.MoveNext())
            throw new ArgumentException("Коллекция пуста", nameof(collection));

        var maxElement = enumerator.Current;
        var maxValue = convertToNumber(maxElement);

        while (enumerator.MoveNext())
        {
            var value = convertToNumber(enumerator.Current);
            if (!(value > maxValue)) continue;
            maxValue = value;
            maxElement = enumerator.Current;
        }

        return maxElement;
    }
}