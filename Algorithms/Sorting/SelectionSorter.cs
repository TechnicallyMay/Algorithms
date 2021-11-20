namespace Algorithms.Sorting;

internal class SelectionSorter : IInPlaceSorter<int>
{
    public void Sort(int[] items)
    {
        for (int i = 0; i < items.Length - 1; i++)
        {
            int smallestIndex = i;
            for (int j = i + 1; j < items.Length; j++)
            {
                if (items[j] < items[smallestIndex])
                    smallestIndex = j;
            }

            int copy = items[i];

            items[i] = items[smallestIndex];
            items[smallestIndex] = copy;
        }
    }
}
