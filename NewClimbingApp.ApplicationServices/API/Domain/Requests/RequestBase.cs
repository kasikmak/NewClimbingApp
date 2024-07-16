using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Domain.Requests;

public class RequestBase
{
    [JsonIgnore]
    public string? AuthenticationName { get; set; }
    [JsonIgnore]
    public string? AuthenticationRole { get; set; }
    [JsonIgnore]
    public string? AuthenticationId { get; set; }
}
