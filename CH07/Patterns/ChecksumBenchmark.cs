using BenchmarkDotNet.Attributes;
using System;

namespace Patterns;
public class ChecksumBenchmark
{
    public byte[] InitBuffer => getBuffer();

    private static byte[] getBuffer()
    {
        var buffer = new byte[1_000_000];
        //var rnd = new Random();
        //rnd.NextBytes(buffer);
        return buffer;
    }

    [Benchmark]
    public int CalculateChecksum()
    {
        return Checksum.CalculateChecksum(InitBuffer);
    }

    [Benchmark]
    public int CalculateChecksumParallel()
    {
        return Checksum.CalculateChecksumParallel(InitBuffer);
    }
}
