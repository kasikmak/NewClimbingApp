using AutoMapper;
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
using MediatR;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Ascents;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Ascents;
using NewClimbingApp.ApplicationServices.API.Domain.ErrorHandling;

namespace NewClimbingApp.ApplicationServices.API.Handlers.Ascents;

public class GetAscentsByRouteIdHandler : IRequestHandler<GetAscentByRouteIdRequest, GetAscentsByRouteIdResponse>
{
    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor;

    public GetAscentsByRouteIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        this.mapper = mapper;
        this.queryExecutor = queryExecutor;
    }

    public async Task<GetAscentsByRouteIdResponse> Handle(GetAscentByRouteIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetAscentsQuery { RouteId = request.RouteId };
        var ascent = await this.queryExecutor.Execute(query);
        if (ascent == null)
        {
            new GetAscentsByRouteIdResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }
        var response = new GetAscentsByRouteIdResponse
        {
            Data = mapper.Map<List<AscentDto>>(ascent)
        };
        return response;
    }
}
