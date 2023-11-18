using BenchmarkDotNet.Running;
using static IO.FileCopy;

namespace IO;
class Program
{
    public static void Main(string[] args)
    {
        //Trace.Listeners.Add(new DefaultTraceListener());
        var suite = new FileCopyBenchmark();
        suite.CopyAsyncOld(256 * 1024);
        suite.CopyAsyncOld(256 * 1024);
        BenchmarkRunner.Run<FileCopyBenchmark>();
    }
}
