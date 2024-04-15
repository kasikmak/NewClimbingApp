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
        /*var query = new GetRouteQuery { Id = request.RouteId };
        var routeToUpdate = await queryExecutor.Execute(query);
        if(routeToUpdate == null) 
        {
            new AddAscentResponse
            {
                Error = new Domain.ErrorHandling.ErrorModel(ErrorType.NotFound)
            };
        }*/
        var ascent = mapper.Map<Ascent>(request);
        var command = new AddAscentCommand
        {
            Parameter = ascent
        };
        var ascentAdded = await commandExecutor.Execute(command);
        /*  routeToUpdate.Ascent.IsClimbed = true;
          var command2 = new UpdateAscentCommand
          {
              Parameter = ascentToAdd,
          };
          var addedAscent = await commandExecutor.Execute(command2)*/
        return new AddAscentResponse
        {
            Data = mapper.Map<AscentDto>(ascentAdded)
        };
    }
}
