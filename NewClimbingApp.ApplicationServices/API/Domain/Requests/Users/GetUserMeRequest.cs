using MediatR;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Domain.Requests.Users;

public class GetUserMeRequest : RequestBase, IRequest<GetUserMeResponse>
{
    public string Me {  get; set; }
}
