using Algorithms.Sorting.Helpers;

namespace Algorithms.Sorting;

internal class QuickSorter : IInPlaceSorter<int>
{
    private readonly IPivotPickingStrategy _pivotPickingStrategy;

    public QuickSorter(IPivotPickingStrategy pivotPickingStrategy)
    {
        _pivotPickingStrategy = pivotPickingStrategy;
    }

    public void Sort(int[] items)
    {
        QuickSort(items, 0, items.Length - 1);
    }

    public void QuickSort(int[] items, int startIndex, int endIndex)
    {
        if (startIndex >= endIndex || items?.Length is not > 1)
            return;

        int pivot = _pivotPickingStrategy.FindPivot(items, startIndex, endIndex);
        int pivotValue = items[pivot];

        //Move our pivot to the end
        Swap(items, pivot, endIndex);

        int leftIndex = startIndex;
        //Pivot is at the end, so we'll take care of everything before it
        int rightIndex = endIndex - 1;

        while (true)
        {
            leftIndex = FindIndexOfElementAtLeft(items, leftIndex, endIndex, pivotValue);
            rightIndex = FindIndexOfElementAtRight(items, rightIndex, startIndex, pivotValue);

            if (leftIndex >= rightIndex)
                break;

            Swap(items, leftIndex, rightIndex);
        }

        Swap(items, endIndex, leftIndex);

        QuickSort(items, startIndex, leftIndex - 1);
        QuickSort(items, leftIndex + 1, endIndex);
    }

    private int FindIndexOfElementAtLeft(int[] items, int currentIndex, int maxIndex, int pivotValue)
    {
        while (currentIndex < maxIndex && items[currentIndex] <= pivotValue)
        {
            ++currentIndex;
        }

        return currentIndex;
    }

    private int FindIndexOfElementAtRight(int[] items, int currentIndex, int minIndex, int pivotValue)
    {
        while (currentIndex > minIndex && items[currentIndex] >= pivotValue)
        {
            --currentIndex;
        }

        return currentIndex;
    }

    private void Swap(int[] items, int fromIndex, int toIndex)
    {
        int fromCopy = items[fromIndex];

        items[fromIndex] = items[toIndex];
        items[toIndex] = fromCopy;
    }
}
