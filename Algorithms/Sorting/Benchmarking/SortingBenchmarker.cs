using System.Diagnostics;

namespace Algorithms.Sorting.Benchmarking;

internal class SortingBenchmarker
{
    private readonly IInPlaceSorter<int> sorter;
    private readonly BenchmarkingOptions options;

    public SortingBenchmarker(IInPlaceSorter<int> sorter, BenchmarkingOptions options)
    {
        this.sorter = sorter;
        this.options = options;
    }

    public void Benchmark()
    {
        var runTimes = new TimeSpan[options.NumberOfCollections];

        for (int i = 0; i < options.NumberOfCollections; i++)
        {
            int[] collection = GenerateCollection(options.CollectionLength);
            int[] originalCollection = new int[collection.Length];
            collection.CopyTo(originalCollection, 0);

            Stopwatch sw = new();

            sw.Start();
            sorter.Sort(collection);
            sw.Stop();

            runTimes[i] = sw.Elapsed;

            VerifyCollectionSort(originalCollection, collection);
        }

        LogBenchmarkStats(runTimes);
    }

    private int[] GenerateCollection(int length)
    {
        int[] newCollection = new int[length];

        Random random = new();
        for (int i = 0; i < length; i++)
        {
            newCollection[i] = random.Next(options.ElementRange.Start.Value, options.ElementRange.End.Value);
        }

        return newCollection;
    }

    private void VerifyCollectionSort(int[] original, int[] collection)
    {
        //Sort the original collection using the framework, compare it to collection sorted by algorithm
        if (!original.OrderBy(e => e).SequenceEqual(collection))
            throw new IncorrectlySortedException();
    }

    private void LogBenchmarkStats(TimeSpan[] runTimes)
    {
        double averageSeconds = runTimes.Average(rt => rt.TotalSeconds);

        string sorterName = sorter.GetType().Name;
        double totalRuntime = runTimes.Sum(rt => rt.TotalSeconds);

        Console.WriteLine($"{sorterName} sorted {options.NumberOfCollections} collections of {options.CollectionLength} in {totalRuntime} seconds");
        Console.WriteLine($"Average runtime: {averageSeconds} seconds");
        Console.WriteLine($"Minimum runtime {runTimes.Min(r => r.TotalSeconds)}");
        Console.WriteLine($"Maximum runtime {runTimes.Max(r => r.TotalSeconds)}");
        Console.WriteLine();
    }
}
