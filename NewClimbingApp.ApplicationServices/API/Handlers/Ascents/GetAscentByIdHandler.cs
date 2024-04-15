using AutoMapper;
using NewClimbingApp.ApplicationServices.API.Domain.ErrorHandling;
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

namespace NewClimbingApp.ApplicationServices.API.Handlers.Ascents;

public class GetAscentByIdHandler : IRequestHandler<GetAscentByIdRequest, GetAscentByIdResponse>
{
    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor;

    public GetAscentByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        this.mapper = mapper;
        this.queryExecutor = queryExecutor;
    }

    public async Task<GetAscentByIdResponse> Handle(GetAscentByIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetAscentQuery { Id = request.Id };
        var route = await this.queryExecutor.Execute(query);
        if (route == null)
        {
            new GetAscentByIdResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }
        var response = new GetAscentByIdResponse
        {
            Data = mapper.Map<AscentDto>(route)
        };
        return response;
    }
}
