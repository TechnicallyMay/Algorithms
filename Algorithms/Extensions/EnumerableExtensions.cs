namespace Algorithms.Extensions;

internal static class EnumerableExtensions
{
    public static bool HasSameElementsAs<T>(this IEnumerable<T> source, IEnumerable<T> elements)
    {
        return source.OrderBy(e => e)
            .SequenceEqual(elements.OrderBy(e => e));
    }
}
