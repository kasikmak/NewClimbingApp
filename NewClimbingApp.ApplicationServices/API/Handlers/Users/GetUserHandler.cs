using AutoMapper;
using MediatR;
using NewClimbingApp.ApplicationServices.API.Domain.Models;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Users;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Users;
using NewClimbingApp.DataAccess.CQRS;
using NewClimbingApp.DataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Handlers.Users;

public class GetUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
{
    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor;

    public GetUserHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        this.mapper = mapper;
        this.queryExecutor = queryExecutor;
    }

    public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        var query = new GetUserQuery { UserId = request.UserId};
        var user = await this.queryExecutor.Execute(query);
        var mappedUser = this.mapper.Map<UserDto>(user);
        var response = new GetUserResponse
        {
            Data = mappedUser
        };
        return response;
    }
}
