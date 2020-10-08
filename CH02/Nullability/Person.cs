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

internal class ConferenceRegistration2
{
    public string CampaignSource { get; private set; }
    public string FirstName { get; private set; }
    public string? MiddleName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public DateTimeOffset CreatedOn { get; private set; } = DateTime.Now;

    public ConferenceRegistration2(
        string firstName,
        string? middleName,
        string lastName,
        string email,
        string? campaignSource = null)
    {
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
        Email = email;
        CampaignSource = campaignSource ?? "organic";
    }
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