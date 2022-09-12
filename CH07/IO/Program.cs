using BenchmarkDotNet.Running;
using System.Diagnostics;
using static IO.FileCopy;

namespace IO;
class Program
{
    public static void Main(string[] args)
    {
        //Trace.Listeners.Add(new DefaultTraceListener());
        var suite = new FileCopyBenchmark();
        suite.Setup();
        suite.CopyAsyncOld(256 * 1024);
        suite.CopyAsyncOld(256 * 1024);
        BenchmarkRunner.Run<FileCopyBenchmark>();
    }
}
