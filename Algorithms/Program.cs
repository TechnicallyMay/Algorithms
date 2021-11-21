using Algorithms.Sorting;
using Algorithms.Sorting.Benchmarking;
using Algorithms.Sorting.Helpers;

BenchmarkingOptions options = new()
{
    CollectionLength = 10_000,
    NumberOfCollections = 1000,
    ElementRange = new Range(0, 1000),
};

IInPlaceSorter<int>[] sorters =
{
    new QuickSorter(new MedianOfThreePivotPickingStrategy()),
    new InsertionSorter(),
    new BubbleSorter(),
    new SelectionSorter()
};

foreach (var sorter in sorters)
{
    new SortingBenchmarker(sorter, options).Benchmark();
}

Console.ReadLine();
