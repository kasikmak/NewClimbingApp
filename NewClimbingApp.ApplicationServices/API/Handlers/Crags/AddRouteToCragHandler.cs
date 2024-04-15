using AutoMapper;
using NewClimbingApp.ApplicationServices.API.Domain.Models;
using NewClimbingApp.DataAccess.CQRS.Commands;
using NewClimbingApp.DataAccess.CQRS.Queries;
using NewClimbingApp.DataAccess.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Crags;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Crags;
using MediatR;
using Azure;
using NewClimbingApp.ApplicationServices.API.Domain.ErrorHandling;

namespace NewClimbingApp.ApplicationServices.API.Handlers.Crags;

public class AddRouteToCragHandler : IRequestHandler<AddRouteToCragRequest, AddRouteToCragResponse>
{

    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor;
    private readonly ICommandExecutor commandExecutor;

    public AddRouteToCragHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
    {
        this.mapper = mapper;
        this.queryExecutor = queryExecutor;
        this.commandExecutor = commandExecutor;
    }
    public async Task<AddRouteToCragResponse> Handle(AddRouteToCragRequest request, CancellationToken cancellationToken)
    {
        var routeQuery = new GetRouteQuery 
        {
            Id = request.RouteId 
        };
        var routeToAdd = await queryExecutor.Execute(routeQuery);
        if(routeToAdd == null)
        {
            return new AddRouteToCragResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }
        var cragQuery = new GetCragQuery
        {
            Id = request.CragId 
        };
        var cragToUpdate = await queryExecutor.Execute(cragQuery);
        if (cragToUpdate == null)
        {
            return new AddRouteToCragResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }
        cragToUpdate.Routes.Add(routeToAdd);

        var command = new AddRouteToCragCommand
        {
            Parameter = cragToUpdate
        };
        var updatedCrag = await commandExecutor.Execute(command);

        var response = new AddRouteToCragResponse()
        {
            Data = mapper.Map<CragDto>(updatedCrag)
        };
        return response;
    }
}
