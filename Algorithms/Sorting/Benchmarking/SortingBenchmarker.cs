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

            Stopwatch sw = new();

            sw.Start();
            sorter.Sort(collection);
            sw.Stop();

            runTimes[i] = sw.Elapsed;

            VerifyCollectionSort(collection);
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

    private void VerifyCollectionSort(int[] collection)
    {
        for (int i = 0; i < collection.Length - 1; i++)
        {
            if (collection[i] > collection[i + 1])
                throw new IncorrectlySortedException();
        }
    }

    private void LogBenchmarkStats(TimeSpan[] runTimes)
    {
        double averageSeconds = runTimes.Average(rt => rt.TotalSeconds);

        string sorterName = sorter.GetType().Name;

        Console.WriteLine($"{sorterName} sorted {options.NumberOfCollections} collections of {options.CollectionLength}");
        Console.WriteLine($"Average runtime: {averageSeconds} seconds");
        Console.WriteLine($"Minimum runtime {runTimes.Min(r => r.TotalSeconds)}");
        Console.WriteLine($"Maximum runtime {runTimes.Max(r => r.TotalSeconds)}");
    }
}
