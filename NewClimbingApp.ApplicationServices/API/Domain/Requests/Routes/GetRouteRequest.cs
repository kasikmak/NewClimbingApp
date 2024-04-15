using MediatR;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Domain.Requests.Routes;

public class GetRouteRequest : RequestBase, IRequest<GetRouteResponse>
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Grade { get; set; }   
}
