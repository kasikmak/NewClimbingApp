using AutoMapper;
using MediatR;
using NewClimbingApp.ApplicationServices.API.Domain.ErrorHandling;
using NewClimbingApp.ApplicationServices.API.Domain.Models;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Crags;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Crags;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Users;
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

public class AddCragHandler : IRequestHandler<AddCragRequest, AddCragResponse>
{
    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor;
    private readonly ICommandExecutor commandExecutor;

    public AddCragHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
    {
        this.mapper = mapper;
        this.queryExecutor = queryExecutor;
        this.commandExecutor = commandExecutor;
    }

    public async Task<AddCragResponse> Handle(AddCragRequest request, CancellationToken cancellationToken)
    {
        var query = new GetCragQuery()
        {
            Name = request.Name.ToLower()
            
        };
        var crag = await this.queryExecutor.Execute(query);
        if (crag != null)
        {
            return new AddCragResponse()
            {
                Error = new ErrorModel(ErrorType.Conflict)
            };
        }
        var cragToAdd = mapper.Map<Crag>(request);
        var command = new AddCragCommand 
        {
            Parameter = cragToAdd
        };
        var cragFromDb = await commandExecutor.Execute(command);
        return new AddCragResponse
        {
            Data = mapper.Map<CragDto>(cragFromDb)
        };
    }
}
