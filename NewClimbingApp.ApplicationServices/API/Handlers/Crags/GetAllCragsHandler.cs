using AutoMapper;
using MediatR;
using NewClimbingApp.ApplicationServices.API.Domain.ErrorHandling;
using NewClimbingApp.ApplicationServices.API.Domain.Models;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Crags;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Crags;
using NewClimbingApp.DataAccess.CQRS;
using NewClimbingApp.DataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Handlers.Crags;

public class GetAllCragsHandler : IRequestHandler<GetAllCragsRequest, GetAllCragsResponse>
{
    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor;

    public GetAllCragsHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        this.mapper = mapper;
        this.queryExecutor = queryExecutor;
    }

    public async Task<GetAllCragsResponse> Handle(GetAllCragsRequest request, CancellationToken cancellationToken)
    {
        var query = new GetAllCragsQuery();
        var crags = await queryExecutor.Execute(query);
        if(crags== null)
        {
            new GetAllCragsResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }
        return new GetAllCragsResponse
        {
            Data = mapper.Map<List<CragDto>>(crags)
        };

    }
}
