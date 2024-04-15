using MediatR;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Routes;
using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static NewClimbingApp.DataAccess.Entities.Ascent;
using static NewClimbingApp.DataAccess.Entities.Route;

namespace NewClimbingApp.ApplicationServices.API.Domain.Requests.Routes
{
    public class AddRouteRequest : RequestBase, IRequest<AddRouteResponse>
    {
        public string Name { get; set; }
        public string Grade { get; set; }
        public int? Length { get; set; }
        public bool IsClimbed { get; set; }
        public int? CragId { get; set; }
        public RouteType Type { get; set; }
        public int? AscentId { get; set; }
        [JsonIgnore]
        public float GradeAsFloat {  get; set; }
               
        //public Ascent Ascent { get; set; }
    }
}
