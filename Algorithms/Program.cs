using Algorithms.Sorting;
using Algorithms.Sorting.Benchmarking;

BenchmarkingOptions options = new()
{
    CollectionLength = 10_000,
    NumberOfCollections = 100,
    ElementRange = new Range(0, 10),
};

IInPlaceSorter<int>[] sorters =
{
    new InsertionSorter(),
    new BubbleSorter(),
    new SelectionSorter()
};

foreach (var sorter in sorters)
{
    new SortingBenchmarker(sorter, options).Benchmark();
}

Console.ReadLine();