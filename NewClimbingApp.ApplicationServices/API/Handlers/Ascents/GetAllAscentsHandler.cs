using AutoMapper;
using MediatR;
using NewClimbingApp.ApplicationServices.API.Domain.ErrorHandling;
using NewClimbingApp.ApplicationServices.API.Domain.Models;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Ascents;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Ascents;
using NewClimbingApp.DataAccess.CQRS;
using NewClimbingApp.DataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Handlers.Ascents;

public class GetAllAscentsHandler : IRequestHandler<GetAllAscentsRequest, GetAllAscentsResponse>
{
    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor;
    private readonly ICommandExecutor commandExecutor;

    public GetAllAscentsHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
    {
        this.mapper = mapper;
        this.queryExecutor = queryExecutor;
        this.commandExecutor = commandExecutor;
    }

    public async Task<GetAllAscentsResponse> Handle(GetAllAscentsRequest request, CancellationToken cancellationToken)
    {
        var query = new GetAscentsQuery();
        var ascents = await queryExecutor.Execute(query);
        if(ascents == null)
        {
            new GetAllAscentsResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }
        return new GetAllAscentsResponse()
        {
            Data = this.mapper.Map<List<AscentDto>>(ascents)
        };
    }
}
