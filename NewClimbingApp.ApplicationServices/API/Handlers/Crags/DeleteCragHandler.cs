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

public class DeleteCragHandler : IRequestHandler<DeleteCragRequest, DeleteCragResponse>
{
    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor;
    private readonly ICommandExecutor commandExecutor;

    public DeleteCragHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
    {
        this.mapper = mapper;
        this.queryExecutor = queryExecutor;
        this.commandExecutor = commandExecutor;
    }

    public async Task<DeleteCragResponse> Handle(DeleteCragRequest request, CancellationToken cancellationToken)
    {
        if(request.AuthenticationRole == "Guest" ||request.AuthenticationRole == "Climber")
        {
            return new DeleteCragResponse
            {
                Error = new ErrorModel(ErrorType.Forbidden)
            };
        }
        var query = new GetCragQuery { Id = request.Id };
        var cragToDelete = await queryExecutor.Execute(query);
        if (cragToDelete != null)
        {
            new DeleteCragResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }
        var command = new DeleteCragCommand
        {
            Parameter = cragToDelete
        };
        var deletedCrag = await commandExecutor.Execute(command);
        return new DeleteCragResponse()
        {
            Data = this.mapper.Map<CragDto>(deletedCrag)
        };
    }
}
