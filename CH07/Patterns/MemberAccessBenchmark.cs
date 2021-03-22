using BenchmarkDotNet.Attributes;

namespace Patterns {
  public class MemberAccessBenchmark {
    public UserPreferences prefs;
    public UserPreferences2 prefs2;

    [Benchmark]
    public int ByteMemberAccess() {
      return prefs.ItemsPerPage
        + prefs.NumberOfItemsOnTheHomepage
        + prefs.NumberOfAdClicksICanStomach
        + prefs.MaxNumberOfTrollsInADay
        + prefs.NumberOfCookiesIAmWillingToAccept
        + prefs.NumberOfSpamEmailILoveToGetPerDay;
    }

    [Benchmark]
    public int IntMemberAccess() {
      return prefs2.ItemsPerPage
        + prefs2.NumberOfItemsOnTheHomepage
        + prefs2.NumberOfAdClicksICanStomach
        + prefs2.MaxNumberOfTrollsInADay
        + prefs2.NumberOfCookiesIAmWillingToAccept
        + prefs2.NumberOfSpamEmailILoveToGetPerDay;
    }
  }
}
