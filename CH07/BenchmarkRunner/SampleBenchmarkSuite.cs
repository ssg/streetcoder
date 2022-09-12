using BenchmarkDotNet.Attributes;
using System;

namespace SimpleBenchmarkRunner;
public class SampleBenchmarkSuite
{
    [Params(1000)]
    public int A;

    [Params(35)]
    public int B;

    [Benchmark]
    public int Manual()
    {
        int division = A / B;
        int remainder = A % B;
        return division + remainder;
    }

    [Benchmark]
    public int DivRem()
    {
        int division = Math.DivRem(A, B, out int remainder);
        return division + remainder;
    }
}