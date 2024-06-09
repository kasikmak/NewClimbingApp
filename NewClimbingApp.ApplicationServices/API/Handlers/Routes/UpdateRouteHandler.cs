using AutoMapper;
using MediatR;
using NewClimbingApp.ApplicationServices.API.Domain.Components;
using NewClimbingApp.ApplicationServices.API.Domain.ErrorHandling;
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
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Handlers.Routes;

public class UpdateRouteHandler : IRequestHandler<UpdateRouteRequest, UpdateRouteResponse>
{
    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor;
    private readonly ICommandExecutor commandExecutor;

    public UpdateRouteHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
    {
        this.mapper = mapper;
        this.queryExecutor = queryExecutor;
        this.commandExecutor = commandExecutor;
    }

    public async Task<UpdateRouteResponse> Handle(UpdateRouteRequest request, CancellationToken cancellationToken)
    {
        var query = new GetRouteQuery { Id = request.Id };
        var route = await queryExecutor.Execute(query);
        if (route == null)
        {
            new UpdateRouteResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }
        var routeToUpdate = mapper.Map<Route>(request);
        var command = new UpdateRouteCommand
        {
            Grade = routeToUpdate.Grade.ToUpper(),
            GradeAsFloat = routeToUpdate.Grade.ToUpper().ConvertGrades(),
            Parameter = routeToUpdate,           
        };
        var updatedRoute = await commandExecutor.Execute(command);
        var response = new UpdateRouteResponse
        {
            Data = mapper.Map<RouteDto>(updatedRoute)
        };
        return response;        
    }
}
