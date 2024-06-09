using AutoMapper;
using MediatR;
using NewClimbingApp.ApplicationServices.API.Domain.ErrorHandling;
using NewClimbingApp.ApplicationServices.API.Domain.Models;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Ascents;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Ascents;
using NewClimbingApp.DataAccess.CQRS;
using NewClimbingApp.DataAccess.CQRS.Commands;
using NewClimbingApp.DataAccess.CQRS.Queries;
using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Handlers.Ascents;

public class AddAscentHandler : IRequestHandler<AddAscentRequest, AddAscentResponse>
{
    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor;
    private readonly ICommandExecutor commandExecutor;

    public AddAscentHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
    {
        this.mapper = mapper;
        this.queryExecutor = queryExecutor;
        this.commandExecutor = commandExecutor;
    }
    public async Task<AddAscentResponse> Handle(AddAscentRequest request, CancellationToken cancellationToken)
    {        
        var query = new GetRouteQuery
        {
            Id = request.RouteId
        };
        var route = await queryExecutor.Execute(query);
        if(route == null)
        {
            return new AddAscentResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }
        var ascent = mapper.Map<Ascent>(request);
        var userIdstring = request.AuthenticationId;
        var userId = int.Parse(userIdstring);        
        var command = new AddAscentCommand
        {
           
            Parameter = ascent,
            ClimberId = userId,
        };
        var ascentAdded = await commandExecutor.Execute(command);        
        return new AddAscentResponse
        {
            Data = mapper.Map<AscentDto>(ascentAdded)
        };
    }
}
