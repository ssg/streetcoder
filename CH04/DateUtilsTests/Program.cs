#if !DEBUG
#error Debug.Asserts will only run in Debug configuration
#endif

using System;
using System.Diagnostics;

namespace DateUtilsTests
{
    public class Program
    {
        public static void Main_()
        {
            var span = TimeSpan.FromSeconds(3);
            Debug.Assert(span.ToIntervalString() == "3s", "3s case failed");
            span = TimeSpan.FromMinutes(5);
            Debug.Assert(span.ToIntervalString() == "5m", "5m case failed");
            span = TimeSpan.FromHours(7);
            Debug.Assert(span.ToIntervalString() == "7h", "7h case failed");
            span = TimeSpan.FromMilliseconds(1); // less than a second
            Debug.Assert(span.ToIntervalString() == "now", "now case failed");
        }
    }
}