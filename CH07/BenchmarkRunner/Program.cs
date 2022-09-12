using System;
using System.Diagnostics;
using BenchmarkDotNet.Running;

namespace SimpleBenchmarkRunner;
public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<SampleBenchmarkSuite>();
        runBenchmarks();
    }

    private const int iterations = 1_000_000_000;

    private static void runBenchmarks()
    {
        var suite = new SampleBenchmarkSuite
        {
            A = 1000,
            B = 35
        };

        long manualTime = runBenchmark(() => suite.Manual());
        long divRemTime = runBenchmark(() => suite.DivRem());

        reportResult("Manual", manualTime);
        reportResult("DivRem", divRemTime);
    }

    private static long runBenchmark(Func<int> action)
    {
        var watch = Stopwatch.StartNew();
        for (int n = 0; n < iterations; n++)
        {
            action();
        }
        watch.Stop();
        return watch.ElapsedMilliseconds;
    }

    private static void reportResult(string name, long milliseconds)
    {
        double nanoseconds = milliseconds * 1000000;
        Console.WriteLine("{0} = {1}ns / operation",
          name,
          nanoseconds / iterations);
    }
}