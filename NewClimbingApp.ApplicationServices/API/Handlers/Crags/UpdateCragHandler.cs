using AutoMapper;
using MediatR;
using NewClimbingApp.ApplicationServices.API.Domain.ErrorHandling;
using NewClimbingApp.ApplicationServices.API.Domain.Models;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Crags;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Crags;
using NewClimbingApp.DataAccess.CQRS;
using NewClimbingApp.DataAccess.CQRS.Commands;
using NewClimbingApp.DataAccess.CQRS.Queries;
using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Handlers.Crags;

public class UpdateCragHandler : IRequestHandler<UpdateCragRequest, UpdateCragResponse>
{
    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor;
    private readonly ICommandExecutor commandExecutor;

    public UpdateCragHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
    {
        this.mapper = mapper;
        this.queryExecutor = queryExecutor;
        this.commandExecutor = commandExecutor;
    }
    public async Task<UpdateCragResponse> Handle(UpdateCragRequest request, CancellationToken cancellationToken)
    {
        var query = new GetCragQuery { Id  = request.Id };
        var cragToUpdate = await queryExecutor.Execute(query);
        if(cragToUpdate == null)
        {
            new UpdateCragResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }
        var mappedCrag = mapper.Map<Crag>(request);
        var command = new UpdateCragCommand
        {
            Parameter = mappedCrag
        };
        var updatedCrag = await commandExecutor.Execute(command);
        return new UpdateCragResponse()
        {
            Data = this.mapper.Map<CragDto>(updatedCrag)
        };
    }
}
