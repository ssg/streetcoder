using BenchmarkDotNet.Attributes;
using System.IO;

namespace IO;
public partial class FileCopy
{
    public class FileCopyBenchmark
    {
        private const long fileSize = 100 * 1024 * 1024; // 100mb
        private string sourceFilename;
        private string destinationFilename;

        [GlobalSetup]
        public void Setup()
        {
            sourceFilename = Path.GetTempFileName();
            // grow the file
            using var stream = File.OpenWrite(sourceFilename);
            stream.SetLength(fileSize);
            stream.Close();
            destinationFilename = Path.GetTempFileName();
        }

        [Benchmark]
        [Arguments(1)]
        public void Copy(int bufferSize)
        {
            FileCopy.Copy(sourceFilename, destinationFilename);
        }

        [Benchmark]
        //[Arguments(512)]
        //[Arguments(1024)]
        //[Arguments(16 * 1024)]
        [Arguments(256 * 1024)]
        //[Arguments(1024 * 1024)]
        //[Arguments(2048 * 1024)]
        public void CopyBuffered(int bufferSize)
        {
            FileCopy.CopyBuffered(sourceFilename,
              destinationFilename, bufferSize);
        }

        [Benchmark]
        [Arguments(256 * 1024)]
        public void CopyAsyncOld(int bufferSize)
        {
            var result = FileCopy.CopyAsyncOld(sourceFilename,
              destinationFilename, bufferSize);
            result.Wait();
        }
    }
}
