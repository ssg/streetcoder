using BenchmarkDotNet.Running;
using System;

namespace Patterns; 
public class Program {
public static void Main(string[] args) {
  //BranchPrediction.CheckFive(5);
  //Luhn.CheckUnsafe("1234567890");
  //BenchmarkRunner.Run<MemberAccessBenchmark>();
  //var suite = new ChecksumBenchmark();
  //suite.CalculateChecksum(new byte[123]);
  //suite.CalculateChecksumParallel(new byte[123]);
  //BenchmarkRunner.Run<ChecksumBenchmark>();
  BenchmarkRunner.Run<BufferProcessorBenchmark>();
  //BenchmarkRunner.Run<LuhnBenchmark>();
}
}
