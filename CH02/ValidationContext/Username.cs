using System;

namespace ValidationContext;

public class Username
{
    public const int MaxLength = 50; // have username

    public string Value { get; }

    public Username(string value)
    {
        value = value.Trim(); // normalize spaces
        if (String.IsNullOrEmpty(value)
            || value.Length < 1
            || value.Length > MaxLength)
        {
            throw new ArgumentException("Invalid username", nameof(value));
        }
        this.Value = value;
    }

    public override string ToString() => Value;
}