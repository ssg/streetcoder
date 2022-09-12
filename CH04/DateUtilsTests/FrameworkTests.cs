using NUnit.Framework;
using System;

namespace DateUtilsTests;

internal class DateTimeExtensionsTests
{
    [TestCase("00:00:03.000", ExpectedResult = "3s")]
    [TestCase("00:05:00.000", ExpectedResult = "5m")]
    [TestCase("07:00:00.000", ExpectedResult = "7h")]
    [TestCase("00:00:00.001", ExpectedResult = "now")]
    public string ToIntervalString_ReturnsExpectedValues(
      string timeSpanText)
    {
        var input = TimeSpan.Parse(timeSpanText);
        return input.ToIntervalString();
    }

    [TestCase(18, 0, -1, ExpectedResult = true)]
    [TestCase(18, 0, 0, ExpectedResult = false)]
    [TestCase(18, 0, 1, ExpectedResult = false)]
    [TestCase(18, -1, 0, ExpectedResult = true)]
    [TestCase(18, 1, 0, ExpectedResult = false)]
    [TestCase(19, 0, 0, ExpectedResult = true)]
    [TestCase(17, 0, 0, ExpectedResult = false)]
    public bool IsLegalBirthdate_ReturnsExpectedValues(
      int yearDifference, int monthDifference, int dayDifference)
    {
        var now = DateTime.Now;
        var input = now.AddYears(-yearDifference)
          .AddMonths(monthDifference)
          .AddDays(dayDifference);
        return DateTimeExtensions.IsLegalBirthdate(input);
    }
}