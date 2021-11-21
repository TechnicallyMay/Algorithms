namespace Algorithms.Sorting;

internal class CountingSorter : IOutOfPlaceSorter<int>
{
    private readonly int _maxElementValue;

    public CountingSorter(int maxElementValue)
    {
        _maxElementValue = maxElementValue;
    }

    public int[] Sort(int[] items)
    {
        var counts = new int[_maxElementValue];

        foreach (int item in items)
        {
            ++counts[item];
        }

        for (int i = 1; i < counts.Length; i++)
        {
            counts[i] = counts[i - 1] + counts[i];
        }

        int[] sorted = new int[items.Length];

        foreach (int item in items)
        {
            sorted[--counts[item]] = item;
        }

        return sorted;
    }
}
