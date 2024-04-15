using AutoMapper;
using MediatR;
using NewClimbingApp.ApplicationServices.API.Domain.ErrorHandling;
using NewClimbingApp.ApplicationServices.API.Domain.Models;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Users;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Users;
using NewClimbingApp.DataAccess.CQRS;
using NewClimbingApp.DataAccess.CQRS.Commands;
using NewClimbingApp.DataAccess.CQRS.Queries;
using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Handlers.Users;

public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
{
    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor;
    private readonly ICommandExecutor commandExecutor;

    public UpdateUserHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
    {
        this.mapper = mapper;
        this.queryExecutor = queryExecutor;
        this.commandExecutor = commandExecutor;
    }
    public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var query = new GetUserQuery
        {
            UserId = request.Id
        };
        var user = await queryExecutor.Execute(query);
        if (user == null)
        {
            return new UpdateUserResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }
        var mappedUser = this.mapper.Map<User>(request);
        var command = new UpdateUserCommand
        {
            Parameter = mappedUser
        };
        var updatedUser = await this.commandExecutor.Execute(command);
        return new UpdateUserResponse
        {
            Data = this.mapper.Map<UserDto>(updatedUser)
        };
    }
}
