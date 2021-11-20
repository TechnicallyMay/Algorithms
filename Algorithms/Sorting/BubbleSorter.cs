namespace Algorithms.Sorting;

internal class BubbleSorter : IInPlaceSorter<int>
{
    public void Sort(int[] items)
    {
        bool sorting = true;
        while (sorting)
        {
            sorting = false;
            for (int i = 0; i < items.Length - 1; i++)
            {
                if (items[i] > items[i + 1])
                {
                    int iCopy = items[i];
                    sorting = true;

                    items[i] = items[i + 1];
                    items[i + 1] = iCopy;
                }

            }
        }
    }
}
