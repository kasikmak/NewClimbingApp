using MediatR;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Domain.Requests.Routes;

public class DeleteRouteRequest : RequestBase, IRequest<DeleteRouteResponse>
{
    public int Id { get; set; }
}
