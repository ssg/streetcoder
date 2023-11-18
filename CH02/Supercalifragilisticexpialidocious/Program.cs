using Microsoft.AspNetCore.Hosting;
using System;
using System.Net;
using System.Text.RegularExpressions;

internal class Program
{
    public static void Main()
    {
        Console.WriteLine("Extremely simple URL shortener");
        _ = new WebHostBuilder()
            .UseUrls("http://localhost:5100", "http://localhost:5101", "http://*:5102")
            .Build();
    }

    // URL format is https://supercalifragilisticexpialidocious.io/<shortcode>
    public string? GetShortCodeStr(string url)
    {
        const string urlValidationPattern = @"^https?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$";
        if (!Regex.IsMatch(url, urlValidationPattern))
        {
            return null; // not a valid URL
        }
        // take the part after the last slash
        string[] parts = url.Split('/');
        string lastPart = parts[^1];
        return lastPart;
    }

    // URL format is https://supercalifragilisticexpialidocious.io/<shortcode>
    public string? GetShortCodeUri(Uri url)
    {
        string path = url.AbsolutePath;
        if (path.Contains('/'))
        {
            return null; // don't allow multiple paths
        }
        return path;
    }

    public static void IPLoopback()
    {
        _ = IPAddress.Loopback;
    }

    public void BirthDateCalculator()
    {
        var now = DateTimeOffset.Now;
        var birthDate =
            new DateTimeOffset(1976, 12, 21, 02, 00, 00,
                TimeSpan.FromHours(2));
        TimeSpan timePassed = now - birthDate;
        Console.WriteLine($"It’s been {timePassed.TotalSeconds} seconds since I was born!");
    }
}