using AutoMapper;
using MediatR;
using NewClimbingApp.ApplicationServices.API.Domain.ErrorHandling;
using NewClimbingApp.ApplicationServices.API.Domain.Models;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Users;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Routes;
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

public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
{
    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor;
    private readonly ICommandExecutor commandExecutor;

    public DeleteUserHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
    {
        this.mapper = mapper;
        this.queryExecutor = queryExecutor;
        this.commandExecutor = commandExecutor;
    }

    public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        var query = new GetUserQuery { UserId = request.Id };
        var userFromDb = await queryExecutor.Execute(query);
        if (userFromDb == null)
        {
            new DeleteUserResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }
        var userToDelete = this.mapper.Map<User>(userFromDb);
        var command = new DeleteUserCommand
        {  
            Parameter = userToDelete
        };
        var deletedUser = await commandExecutor.Execute(command);
        var response = new DeleteUserResponse
        {
            Data = deletedUser
        };
        return response;
    }
}
