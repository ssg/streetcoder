using System;

namespace Algorithms;

internal class Structs
{
    private struct Point
    {
        public int X;
        public int Y;

        public override readonly string? ToString() => $"X:{X},Y:{Y}";
    }

    public static void Main()
    {
        var a = new Point()
        {
            X = 5,
            Y = 5,
        };
        var b = a;
        b.X = 100;
        b.Y = 200;
        Console.WriteLine(b);
        Console.WriteLine(a);
    }
}