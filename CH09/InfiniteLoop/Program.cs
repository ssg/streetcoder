using System;

namespace InfiniteLoop {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("This app runs in an infinite loop");
      Console.WriteLine("It consumes a lot of CPU too!");
      Console.WriteLine("Press Ctrl-C to quit");
      var rnd = new Random();
      infiniteLoopAggressive(rnd.NextDouble());
    }

    private static void infiniteLoopAggressive(double x) {
      while (true) {
        x *= 13;
      }
    }
  }
}
