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

public class DeleteAscentHandler : IRequestHandler<DeleteAscentRequest, DeleteAscentResponse>
{
    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor;
    private readonly ICommandExecutor commandExecutor;

    public DeleteAscentHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
    {
        this.mapper = mapper;
        this.queryExecutor = queryExecutor;
        this.commandExecutor = commandExecutor;
    }

    public async Task<DeleteAscentResponse> Handle(DeleteAscentRequest request, CancellationToken cancellationToken)
    {
        var query = new GetAscentQuery { Id = request.Id };
        var ascentToDelete = await queryExecutor.Execute(query);
        if (ascentToDelete == null)
        {
            new DeleteAscentResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }
        var command = new DeleteAscentCommand
        {
            Parameter = ascentToDelete
        };
        var deletedAscent = await commandExecutor.Execute(command);
        return new DeleteAscentResponse()
        {
            Data = this.mapper.Map<AscentDto>(deletedAscent)
        };
    }
}
