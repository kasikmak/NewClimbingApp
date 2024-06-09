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
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Handlers.Ascents;

public class UpdateAscentHandler : IRequestHandler<UpdateAscentRequest, UpdateAscentResponse>
{
    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor;
    private readonly ICommandExecutor commandExecutor;

    public UpdateAscentHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
    {
        this.mapper = mapper;
        this.queryExecutor = queryExecutor;
        this.commandExecutor = commandExecutor;
    }

    public async Task<UpdateAscentResponse> Handle(UpdateAscentRequest request, CancellationToken cancellationToken)
    {
        var query = new GetAscentQuery { Id = request.Id };
        var ascent = await queryExecutor.Execute(query);
        if(ascent == null) 
        {
            return new UpdateAscentResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }
        var route = await queryExecutor.Execute(query);
        if (route == null)
        {
            return new UpdateAscentResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }
        var mappedAscent = mapper.Map<Ascent>(request);
        var command = new UpdateAscentCommand
        {
            Parameter = mappedAscent
        };
        var updatedAscent = await commandExecutor.Execute(command);
        return new UpdateAscentResponse
        {
            Data = mapper.Map<AscentDto>(updatedAscent)
        };
    }
}
