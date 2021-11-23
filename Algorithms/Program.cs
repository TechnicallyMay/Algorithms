using Algorithms.Sorting;
using Algorithms.Sorting.Benchmarking;
using Algorithms.Sorting.Helpers;

BenchmarkingOptions options = new()
{
    CollectionLength = 1000,
    NumberOfCollections = 1000,
    ElementRange = new Range(0, 1000),
};

ISorter<int>[] sorters =
{
    new BubbleSorter(),
    new CountingSorter(options.ElementRange.End.Value),
    new InsertionSorter(),
    new MergeSorter(),
    new QuickSorter(new MedianOfThreePivotPickingStrategy()),
    new SelectionSorter()
};

foreach (var sorter in sorters)
{
    new SortingBenchmarker(sorter, options).Benchmark();
}

Console.ReadLine();
