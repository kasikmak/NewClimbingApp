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

public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
{
    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor;

    public GetUsersHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        this.mapper = mapper;
        this.queryExecutor = queryExecutor;
    }
    public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
    {
        var query = new GetUsersQuery();
        var users = await this.queryExecutor.Execute(query);
        var mappedUsers = this.mapper.Map<List<UserDto>>(users);
        return new GetUsersResponse
        {
            Data = mappedUsers
        };
    }
}
