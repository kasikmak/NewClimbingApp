using AutoMapper;
using MediatR;
using NewClimbingApp.ApplicationServices.API.Domain.Models;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Routes;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Routes;
using NewClimbingApp.DataAccess.CQRS.Queries;
using NewClimbingApp.DataAccess.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewClimbingApp.ApplicationServices.API.Domain.ErrorHandling;

namespace NewClimbingApp.ApplicationServices.API.Handlers.Routes;

public class GetRoutesByGradeHandler : IRequestHandler<GetRoutesByGradeRequest, GetRoutesByGradeResponse>
{
    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor;

    public GetRoutesByGradeHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        this.mapper = mapper;
        this.queryExecutor = queryExecutor;
    }

    public async Task<GetRoutesByGradeResponse> Handle(GetRoutesByGradeRequest request, CancellationToken cancellationToken)
    {

        var query = new GetRoutesQuery { Grade = request.Grade.ToUpper() };
        var routes = await this.queryExecutor.Execute(query);
        if (routes == null)
        {
            new GetRoutesByGradeResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }
        var mappedRoutes = this.mapper.Map<List<RouteDto>>(routes);
        var response = new GetRoutesByGradeResponse()
        {
            Data = mappedRoutes
        };
        return response;
    }
}
