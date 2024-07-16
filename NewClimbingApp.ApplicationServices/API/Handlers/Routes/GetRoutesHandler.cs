using AutoMapper;
using MediatR;
using NewClimbingApp.ApplicationServices.API.Domain.Components;
using NewClimbingApp.ApplicationServices.API.Domain.ErrorHandling;
using NewClimbingApp.ApplicationServices.API.Domain.Models;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Routes;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Routes;
using NewClimbingApp.DataAccess;
using NewClimbingApp.DataAccess.CQRS;
using NewClimbingApp.DataAccess.CQRS.Queries;
using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Handlers.Routes;

public class GetRoutesHandler : IRequestHandler<GetRoutesRequest, GetRoutesResponse>
{
    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor;
    private readonly IAccuWeather accuweather;

    public GetRoutesHandler(IMapper mapper, IQueryExecutor queryExecutor, IAccuWeather accuweather)
    {        
        this.mapper = mapper;
        this.queryExecutor = queryExecutor;
        this.accuweather = accuweather;
    }

    public async Task<GetRoutesResponse> Handle(GetRoutesRequest request, CancellationToken cancellationToken)
    {        
        var query = new GetRoutesQuery();
        var routes = await this.queryExecutor.Execute(query);
        if (routes == null)
        {
            new GetRoutesResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }
        var mappedRoutes =  this.mapper.Map<List<RouteDto>>(routes);               
        var response = new GetRoutesResponse()
        {
            Data = mappedRoutes 
        };
        return response;
    }
}
