using BenchmarkDotNet.Running;

namespace Patterns;
public struct UserPreferences
{
    public byte ItemsPerPage;
    public byte NumberOfItemsOnTheHomepage;
    public byte NumberOfAdClicksICanStomach;
    public byte MaxNumberOfTrollsInADay;
    public byte NumberOfCookiesIAmWillingToAccept;
    public byte NumberOfSpamEmailILoveToGetPerDay;
}

public struct UserPreferences2
{
    public int ItemsPerPage;
    public int NumberOfItemsOnTheHomepage;
    public int NumberOfAdClicksICanStomach;
    public int MaxNumberOfTrollsInADay;
    public int NumberOfCookiesIAmWillingToAccept;
    public int NumberOfSpamEmailILoveToGetPerDay;
}
