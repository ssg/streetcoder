using System;

namespace Blabber.Models
{
    public static class DateTimeExtensions
    {
        public static string ToIntervalString(
          this TimeSpan interval)
        {
            return interval.TotalHours >= 1.0
                ? $"{(int)interval.TotalHours}h"
                : interval.TotalMinutes >= 1.0
                ? $"{(int)interval.TotalMinutes}m"
                : interval.TotalSeconds >= 1.0
                ? $"{(int)interval.TotalSeconds}s" : "now";
        }
    }
}