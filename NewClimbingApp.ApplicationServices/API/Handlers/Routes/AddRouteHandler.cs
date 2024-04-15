using AutoMapper;
using MediatR;
using NewClimbingApp.ApplicationServices.API.Domain.Models;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Routes;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Routes;
using NewClimbingApp.DataAccess.CQRS;
using NewClimbingApp.DataAccess.CQRS.Commands;
using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Handlers.Routes;

public class AddRouteHandler : IRequestHandler<AddRouteRequest, AddRouteResponse>
{
    private readonly IMapper mapper;
    private readonly ICommandExecutor commandExecutor;

    public AddRouteHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        this.mapper = mapper;
        this.commandExecutor = commandExecutor;
    }

    public async Task<AddRouteResponse> Handle(AddRouteRequest request, CancellationToken cancellationToken)
    {
        var route = this.mapper.Map<Route>(request);

        var command = new AddRouteCommand
        {
            Parameter = route,
            Grade = route.Grade.ToLower(),
        };
        var routeFromDB = await this.commandExecutor.Execute(command);
        return new AddRouteResponse
        {
            Data = mapper.Map<RouteDto>(routeFromDB)
        };
    }   
}
