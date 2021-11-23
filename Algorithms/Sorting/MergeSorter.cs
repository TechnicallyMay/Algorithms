namespace Algorithms.Sorting;

internal class MergeSorter : ISorter<int>
{
    public int[] Sort(int[] items)
    {
        if (items.Length < 2)
            return items;

        var left = Sort(items[..(items.Length / 2)]);
        var right = Sort(items[(items.Length / 2)..]);

        int[] result = new int[left.Length + right.Length];

        int i = 0;
        int j = 0;

        while (i + j < result.Length)
        {
            int leftVal = i < left.Length ? left[i] : int.MaxValue;
            int rightVal = j < right.Length ? right[j] : int.MaxValue;

            if (leftVal < rightVal)
                result[i++ + j] = leftVal;
            else
                result[i + j++] = rightVal;
        }

        return result;
    }
}
