using MediatR;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Domain.Requests.Routes;

public class AddAscentToRouteRequest : RequestBase, IRequest<AddAscentToRouteResponse>
{
    public int AscentId { get; set; }

    public int RouteId { get; set; }

    public string RouteName { get; set; }

}
