using MediatR;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Ascents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Domain.Requests.Ascents;

public class GetAllAscentsRequest : RequestBase, IRequest<GetAllAscentsResponse>
{
}
