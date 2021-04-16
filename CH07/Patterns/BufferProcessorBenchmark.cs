using BenchmarkDotNet.Attributes;

namespace Patterns {
  public class BufferProcessorBenchmark {
    public static int[] Buffer = new int[10_000_000];

    [Benchmark(Baseline = true)]
    public void MultiplyEachClassic() {
      BufferProcessor.MultiplyEachClassic(Buffer, 2);
    }

    [Benchmark]
    public void MultiplyEachSimd() {
      BufferProcessor.MultiplyEachSimd(Buffer, 2);
    }


  }
}
