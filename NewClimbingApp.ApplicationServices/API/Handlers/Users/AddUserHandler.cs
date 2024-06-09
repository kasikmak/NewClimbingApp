using AutoMapper;
using MediatR;
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
using Microsoft.AspNet.Identity;
using NewClimbingApp.ApplicationServices.API.Domain.ErrorHandling;

namespace NewClimbingApp.ApplicationServices.API.Handlers.Users;

public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
{
    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor;
    private readonly ICommandExecutor commandExecutor;
    private readonly IPasswordHasher passwordHasher;

    public AddUserHandler(IMapper mapper,IQueryExecutor queryExecutor, ICommandExecutor commandExecutor, IPasswordHasher passwordHasher)
    {
        this.mapper = mapper;
        this.queryExecutor = queryExecutor;
        this.commandExecutor = commandExecutor;
        this.passwordHasher = passwordHasher;
    }
    public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
    {
        var query = new GetUserQuery()
        {         
            Email = request.Email,            
            UserName = request.UserName
        };

        var user = await this.queryExecutor.Execute(query);
        if (user != null)
        {
            return new AddUserResponse()
            {
                Error = new ErrorModel(ErrorType.Conflict)
            };
        }
        var hashedPassword = passwordHasher.HashPassword(request.Password);
        request.Password = hashedPassword;

        var mappedUser = this.mapper.Map<User>(request);
        var command = new AddUserCommand
        {
            Parameter = mappedUser,
        };
        var registeredUser = await this.commandExecutor.Execute(command);
        return new AddUserResponse
        {
            Data = this.mapper.Map<UserDto>(registeredUser),
        };
    }
}
