namespace Algorithms.Sorting.Helpers;

internal class MedianOfThreePivotPickingStrategy : IPivotPickingStrategy
{
    public int FindPivot(int[] items, int startIndex, int endIndex)
    {
        if (endIndex - startIndex < 3)
            return endIndex;

        int middleIndex = (startIndex + endIndex) / 2;

        int first = items[startIndex];
        int middle = items[middleIndex];
        int last = items[endIndex];

        var sorted = new[] { first, middle, last }.OrderBy(x => x);

        items[startIndex] = sorted.ElementAt(0);
        items[middleIndex] = sorted.ElementAt(1);
        items[endIndex] = sorted.ElementAt(2);

        return middleIndex;
    }
}
