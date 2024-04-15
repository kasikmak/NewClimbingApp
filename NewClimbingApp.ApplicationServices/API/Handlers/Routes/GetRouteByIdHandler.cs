using AutoMapper;
using MediatR;
using NewClimbingApp.ApplicationServices.API.Domain.ErrorHandling;
using NewClimbingApp.ApplicationServices.API.Domain.Models;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Routes;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Routes;
using NewClimbingApp.DataAccess.CQRS;
using NewClimbingApp.DataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Handlers.Routes;

public class GetRouteByIdHandler : IRequestHandler<GetRouteRequest, GetRouteResponse>
{
    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor;

    public GetRouteByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        this.mapper = mapper;
        this.queryExecutor = queryExecutor;
    }

    public async Task<GetRouteResponse> Handle(GetRouteRequest request, CancellationToken cancellationToken)
    {
        var query = new GetRouteQuery { Id = request.Id };
        var route = await this.queryExecutor.Execute(query);
        if (route == null)
        {
            new GetRouteResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }
        var response = new GetRouteResponse
        {
            Data = mapper.Map<RouteDto>(route)
        };
        return response;
    }
}

