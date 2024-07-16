using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NewClimbingApp.ApplicationServices.API.Domain.Components.Models;

public class City
{
    [JsonProperty("Key")]
    public string? LocationKey { get; set; }
}