namespace Algorithms.Sorting;

internal class InsertionSorter : ISorter<int>
{
    public int[] Sort(int[] items)
    {
        if (items?.Length is not > 1)
            return Array.Empty<int>();

        for (int i = 1; i < items.Length; i++)
        {
            int j = i - 1;

            while (j >= 0 && items[j + 1] < items[j])
            {
                int jCopy = items[j];
                items[j] = items[j + 1];
                items[j + 1] = jCopy;
                --j;
            }
        }

        return items;
    }
}
