using System.Collections.Generic;

namespace Arrays;

public class Arrays
{
    private static readonly int[] values = [1, 2, 3, 4];

    public static int ArrayVsList()
    {
        var a = values;
        int sum1 = a[0] + a[1] + a[2] + a[3];
        var b = new List<int>(values);
        int sum2 = b[0] + b[1] + b[2] + b[2];
        return sum1 + sum2;
    }
}