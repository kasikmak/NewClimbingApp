using MediatR;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Ascents;
using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static NewClimbingApp.DataAccess.Entities.Ascent;

namespace NewClimbingApp.ApplicationServices.API.Domain.Requests.Ascents;

public class AddAscentRequest : RequestBase, IRequest<AddAscentResponse>
{
    public bool IsClimbed { get; set; }
    public string Notes { get; set; }
    public float Rating { get; set; }
    public AscentStyle Style { get; set; }

   // public int ClimberId { get; set; }
     
    public int RouteId { get; set; }  
}
