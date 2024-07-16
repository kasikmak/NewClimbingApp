using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Domain.Components.Models;

public partial class Imum
{
    [JsonProperty("Value")]
    public double Value { get; set; }

    [JsonProperty("Unit")]
    public string Unit { get; set; }
}