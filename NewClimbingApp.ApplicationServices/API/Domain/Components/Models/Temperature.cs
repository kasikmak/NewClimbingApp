using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Domain.Components.Models;

public partial class Temperature
{
    [JsonProperty("Minimum")]
    public Imum Minimum { get; set; }

    [JsonProperty("Maximum")]
    public Imum Maximum { get; set; }

}
