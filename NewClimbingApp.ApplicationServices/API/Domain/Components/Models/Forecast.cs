using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Domain.Components.Models;

public partial class DailyForecasts
{
    [JsonProperty("Temperature")]
    public Temperature Temperature { get; set; }
}
