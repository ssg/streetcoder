using System;

public static class DateTimeExtensions
{
    public static string ToIntervalString(
      this TimeSpan interval)
    {
        if (interval.TotalHours >= 1.0)
        {
            return $"{(int)interval.TotalHours}h";
        }
        if (interval.TotalMinutes >= 1.0)
        {
            return $"{(int)interval.TotalMinutes}m";
        }
        if (interval.TotalSeconds >= 1.0)
        {
            return $"{(int)interval.TotalSeconds}s";
        }
        return "now";
    }

    public static bool IsLegalBirthdate(DateTime birthdate)
    {
        const int legalAge = 18;
        var now = DateTime.Now;
        int age = now.Year - birthdate.Year;
        if (age == legalAge)
        {
            return now.Month > birthdate.Month
              || (now.Month == birthdate.Month
                  && now.Day > birthdate.Day);
        }
        return age > legalAge;
    }
}