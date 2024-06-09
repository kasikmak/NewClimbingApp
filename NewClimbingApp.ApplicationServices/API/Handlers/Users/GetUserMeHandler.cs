using AutoMapper;
using MediatR;
using NewClimbingApp.DataAccess.CQRS.Queries;
using NewClimbingApp.DataAccess.CQRS;
using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Users;
using NewClimbingApp.ApplicationServices.API.Domain.Models;
using NewClimbingApp.ApplicationServices.API.Domain.ErrorHandling;

namespace NewClimbingApp.ApplicationServices.API.Domain.Requests.Users;
public class GetUserMeHandler : IRequestHandler<GetUserMeRequest, GetUserMeResponse>
{
    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor;

    public GetUserMeHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        this.mapper = mapper;
        this.queryExecutor = queryExecutor;
    }

    public async Task<GetUserMeResponse> Handle(GetUserMeRequest request, CancellationToken cancellationToken)
    {
        if (request.Me == "Me" || request.Me == "me")
        {
            var query = new GetUserQuery()
            {
                UserName = request.AuthenticationName
            };

            var user = await this.queryExecutor.Execute(query);

            if (user == null)
            {
                new GetUserMeResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappeduser = this.mapper.Map<UserDto>(user);

            return new GetUserMeResponse()
            {
                Data = mappeduser,
            };
        }
        return new GetUserMeResponse()
        {
            Error = new ErrorModel(ErrorType.UnsupportedMethod)
        };
    }
}
