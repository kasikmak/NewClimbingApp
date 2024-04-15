using MediatR;
using NewClimbingApp.ApplicationServices.API.Domain.Models;
using NewClimbingApp.ApplicationServices.API.Domain.Responses;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Crags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Domain.Requests.Crags;

public class DeleteCragRequest : RequestBase, IRequest<DeleteCragResponse>
{
    public int Id { get; set; }
}
