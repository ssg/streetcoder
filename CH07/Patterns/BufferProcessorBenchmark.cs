using BenchmarkDotNet.Attributes;

namespace Patterns;

public class BufferProcessorBenchmark
{
    private static int[] buffer = new int[10_000_000];

    [Benchmark(Baseline = true)]
    public void MultiplyEachClassic()
    {
        BufferProcessor.MultiplyEachClassic(buffer, 2);
    }

    [Benchmark]
    public void MultiplyEachSIMD()
    {
        BufferProcessor.MultiplyEachSIMD(buffer, 2);
    }


}
