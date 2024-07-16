using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewClimbingApp.ApplicationServices.API.Domain.Components;
using NewClimbingApp.ApplicationServices.API.Domain.Components.Models;

namespace NewClimbingApp.Controllers;

[ApiController]
[Route("[controller]")]
public class AccuWeatherController : ApiControllerBase
{
    private readonly IAccuWeather accuweather;

    public AccuWeatherController(IMediator mediator, IAccuWeather accuweather, ILogger<AccuWeatherController> logger) : base(mediator, logger)
    {
        logger.LogInformation("AccuWeather Controller");
        this.accuweather = accuweather;
    }

    [HttpGet("{city}")]
    public async Task<Weather> GetWeather([FromRoute] string city)
    {
        var w = await this.accuweather.Check(city);
        return w;
    }
}
