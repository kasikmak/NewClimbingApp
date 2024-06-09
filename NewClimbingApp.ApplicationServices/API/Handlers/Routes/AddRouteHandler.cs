using AutoMapper;
using MediatR;
using Microsoft.AspNet.Identity;
using NewClimbingApp.ApplicationServices.API.Domain.Components;
using NewClimbingApp.ApplicationServices.API.Domain.Models;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Routes;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Routes;
using NewClimbingApp.DataAccess.CQRS;
using NewClimbingApp.DataAccess.CQRS.Commands;
using NewClimbingApp.DataAccess.CQRS.Queries; 
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
    private readonly IQueryExecutor queryExecutor;

    public AddRouteHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
    {
        this.mapper = mapper;
        this.commandExecutor = commandExecutor;
        this.queryExecutor = queryExecutor;
    }

    public async Task<AddRouteResponse> Handle(AddRouteRequest request, CancellationToken cancellationToken)
    {
        if (request.ClimberId != null)
        {
            var query = new GetUserQuery { UserId = request.ClimberId };
            var climber = await queryExecutor.Execute(query);
            var route = this.mapper.Map<Route>(request);
            var gradeAsFloat = route.Grade.ToUpper().ConvertGrades();
            route.Climbers.Add(climber);
            var command = new AddRouteCommand
            {
                Grade = route.Grade.ToUpper(),
                GradeAsFloat = gradeAsFloat,
                Parameter = route,

            };
            var routeFromDB = await this.commandExecutor.Execute(command);
            return new AddRouteResponse
            {
                Data = mapper.Map<RouteDto>(routeFromDB)
            };
        }
        else
        {
            var route = this.mapper.Map<Route>(request);
            var gradeAsFloat = route.Grade.ToUpper().ConvertGrades();
            var command = new AddRouteCommand
            {
                Grade = route.Grade.ToUpper(),
                GradeAsFloat = gradeAsFloat,
                Parameter = route,
            };
            var routeFromDB = await this.commandExecutor.Execute(command);
            return new AddRouteResponse
            {
                Data = mapper.Map<RouteDto>(routeFromDB)
            };
        }
    }   
}
