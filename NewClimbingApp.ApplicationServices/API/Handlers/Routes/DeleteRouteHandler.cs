﻿using AutoMapper;
using MediatR;
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
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Handlers.Routes;

public class DeleteRouteHandler : IRequestHandler<DeleteRouteRequest, DeleteRouteResponse>
{
    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor;
    private readonly ICommandExecutor commandExecutor;

    public DeleteRouteHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
    {
        this.mapper = mapper;
        this.queryExecutor = queryExecutor;
        this.commandExecutor = commandExecutor;
    }
    public async Task<DeleteRouteResponse> Handle(DeleteRouteRequest request, CancellationToken cancellationToken)
    {
        if (request.AuthenticationRole == "Guest" || request.AuthenticationRole == "Climber")
        {
            return new DeleteRouteResponse
            {
                Error = new ErrorModel(ErrorType.Forbidden)
            };
        }
        var query = new GetRouteQuery { Id = request.Id };
        var routeFromDb = await queryExecutor.Execute(query);
        if(routeFromDb == null) 
        {
            new DeleteRouteResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }
        var routeToDelete = this.mapper.Map<Route>(routeFromDb);
        var command = new DeleteRouteCommand
        {
            Parameter = routeToDelete
        };
        var deletedRoute = await commandExecutor.Execute(command);
        var response = new DeleteRouteResponse
        {
            Data = deletedRoute
        };
        return response;
    }
}
