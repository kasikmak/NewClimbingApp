using MediatR;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Crags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Domain.Requests.Crags;

public class AddRouteToCragRequest : RequestBase, IRequest<AddRouteToCragResponse>
{
    public int RouteId { get; set; }
    public int CragId { get; set; }
}
