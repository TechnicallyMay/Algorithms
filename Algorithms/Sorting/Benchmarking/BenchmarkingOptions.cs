namespace Algorithms.Sorting.Benchmarking;

internal class BenchmarkingOptions
{
    public int NumberOfCollections { get; set; }

    public int CollectionLength { get; set; }

    public Range ElementRange { get; set; } = new Range(0, int.MaxValue);
}
