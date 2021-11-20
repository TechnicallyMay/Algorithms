using Algorithms.Sorting;
using Algorithms.Sorting.Benchmarking;

BenchmarkingOptions options = new()
{
    CollectionLength = 100_000,
    NumberOfCollections = 1,
    ElementRange = new Range(0, 100),
};

var sorter = new BubbleSorter();

new SortingBenchmarker(sorter, options).Benchmark();

Console.ReadLine();