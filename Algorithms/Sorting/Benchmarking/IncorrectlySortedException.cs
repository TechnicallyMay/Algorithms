namespace Algorithms.Sorting.Benchmarking;

internal class IncorrectlySortedException : Exception
{
    public IncorrectlySortedException()
        : base("The collection was incorrectly sorted")
    { }
}
