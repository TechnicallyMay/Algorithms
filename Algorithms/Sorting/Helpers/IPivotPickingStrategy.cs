namespace Algorithms.Sorting.Helpers;

internal interface IPivotPickingStrategy
{
    public int FindPivot(int[] items, int startIndex, int endIndex);
}
