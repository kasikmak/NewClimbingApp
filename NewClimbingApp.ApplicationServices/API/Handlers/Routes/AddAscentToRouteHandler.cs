using AutoMapper;
using MediatR;
using NewClimbingApp.ApplicationServices.API.Domain.Models;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Routes;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Routes;
using NewClimbingApp.DataAccess.CQRS;
using NewClimbingApp.DataAccess.CQRS.Commands;
using NewClimbingApp.DataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Handlers.Routes;

public class AddAscentToRouteHandler : IRequestHandler<AddAscentToRouteRequest, AddAscentToRouteResponse>
{
    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor;
    private readonly ICommandExecutor commandExecutor;

    public AddAscentToRouteHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
    {
        this.mapper = mapper;
        this.queryExecutor = queryExecutor;
        this.commandExecutor = commandExecutor;
    }
    public async Task<AddAscentToRouteResponse> Handle(AddAscentToRouteRequest request, CancellationToken cancellationToken)
    {
        var routeQuery = new GetRouteQuery { Id = request.RouteId };
        var routeWithAscent = await queryExecutor.Execute(routeQuery);
        var ascentQuery = new GetAscentQuery { Id = request.AscentId };
        var ascentToAdd = await queryExecutor.Execute(ascentQuery);

        ascentToAdd.Routes.Add(routeWithAscent);            
        //routeWithAscent.Ascent.IsClimbed = true;

        var command = new AddAscentToRouteCommand
        {
            Parameter = routeWithAscent
        };
        var ascentedRoute = await commandExecutor.Execute(command);

        return new AddAscentToRouteResponse
        {
            Data = mapper.Map<RouteDto>(ascentedRoute)
        };
    }
}
