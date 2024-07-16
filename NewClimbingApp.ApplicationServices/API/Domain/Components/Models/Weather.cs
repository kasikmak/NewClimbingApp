using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NewClimbingApp.ApplicationServices.API.Domain.Components.Models;

public class Weather
{
    [JsonProperty("Headline")]
    public Headline Headline { get; set; }

    [JsonProperty("DailyForecasts")]
    public DailyForecasts[] Temperature { get; set; }
}
