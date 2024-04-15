using MediatR;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static NewClimbingApp.DataAccess.Entities.Route;

namespace NewClimbingApp.ApplicationServices.API.Domain.Requests.Routes;

public class UpdateRouteRequest : RequestBase, IRequest<UpdateRouteResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Grade { get; set; }
    public int? Length { get; set; }
    public RouteType Type { get; set; }
    public int? CragId { get; set; }
    public int? AscentId { get; set; }
    [JsonIgnore]
    public float GradeAsFloat { get; set; }
}
