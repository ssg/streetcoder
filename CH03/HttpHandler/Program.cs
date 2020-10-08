using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Net;

internal static class Program
{
    public static int Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.Error.WriteLine(@"Usage: tempreader <lat>,<lon>

Example: tempreader 38.66,-121.4004");
            return 1;
        }
        args = args[0].Split(',');
        double lat = double.Parse(args[0].Trim());
        double lon = double.Parse(args[1].Trim());
        double? result = getTemperature(lat, lon);
        if (result is null)
        {
            Console.Error.WriteLine("Failed the API request");
            return 1;
        }
        Console.WriteLine(
          $"Temperature at {lat},{lon} is {result}°F");
        return 0;
    }

    private static double? getTemperature(double latitude,
      double longitude)
    {
        const string apiUrl = "https://api.weather.gov";
        string coordinates = $"{latitude},{longitude}";
        string requestPath = $"/points/{coordinates}/forecast/hourly";

        var client = new RestClient(apiUrl);
        var request = new RestRequest(requestPath);
        var response = client.Get(request);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            dynamic obj = JObject.Parse(response.Content);
            var period = obj.properties.periods[0];
            return (double)period.temperature;
        }
        return null;
    }
}