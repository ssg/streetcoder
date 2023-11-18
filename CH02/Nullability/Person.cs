using System;

#nullable enable
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

internal class ConferenceRegistration
{
    public string CampaignSource { get; set; }
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
}

#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

internal class ConferenceRegistration2(
    string firstName,
    string? middleName,
    string lastName,
    string email,
    string campaignSource = "organic")
{
    public string CampaignSource { get; } = campaignSource;
    public string FirstName { get; } = firstName;
    public string? MiddleName { get; } = middleName;
    public string LastName { get; } = lastName;
    public string Email { get; } = email;
    public DateTimeOffset CreatedOn { get; } = DateTime.Now;
}

internal class ConferenceRegistration3
{
    public string CampaignSource { get; set; } = "organic";
    public string FirstName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTimeOffset CreatedOn { get; set; }
}

#nullable restore