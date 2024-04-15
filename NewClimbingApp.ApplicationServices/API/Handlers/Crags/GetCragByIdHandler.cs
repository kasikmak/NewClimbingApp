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

public class GetCragByIdHandler : IRequestHandler<GetCragByIdRequest, GetCragByIdResponse>
{
    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor;

    public GetCragByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        this.mapper = mapper;
        this.queryExecutor = queryExecutor;
    }

    public async Task<GetCragByIdResponse> Handle(GetCragByIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetCragQuery { Id = request.Id };
        var crag = await queryExecutor.Execute(query);
        if(crag == null) 
        {
            return new GetCragByIdResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }
        return new GetCragByIdResponse()
        {
            Data = mapper.Map<CragDto>(crag)
        };
    }
}
