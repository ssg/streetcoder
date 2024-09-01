using System.Collections.Generic;

namespace Arrays;

public class Arrays
{
    public static int ArrayVsList()
    {
        var a = new int[] { 1, 2, 3, 4 };
        int sum1 = a[0] + a[1] + a[2] + a[3];
        var b = new List<int>(new int[] { 1, 2, 3, 4 });
        int sum2 = b[0] + b[1] + b[2] + b[2];

        return sum1 + sum2;
    }
}