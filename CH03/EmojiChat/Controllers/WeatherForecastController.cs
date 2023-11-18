using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmojiChat.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(ILogger<WeatherForecastController> logger) : ControllerBase
{
    private static readonly string[] summaries = [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", 
        "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        logger.LogDebug("GET request received");
        var rng = new Random();
        return Enumerable.Range(1, 5)
            .Select(index => new WeatherForecast(
                Date: DateTime.Now.AddDays(index),
                TemperatureC: rng.Next(-20, 55),
                Summary: summaries[rng.Next(summaries.Length)]))
            .ToArray();
    }
}