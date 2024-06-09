using AutoMapper;
using MediatR;
using NewClimbingApp.ApplicationServices.API.Domain.ErrorHandling;
using NewClimbingApp.ApplicationServices.API.Domain.Models;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Users;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Users;
using NewClimbingApp.DataAccess.CQRS;
using NewClimbingApp.DataAccess.CQRS.Commands;
using NewClimbingApp.DataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Handlers.Users;

public class AddRouteToUserHandlern : IRequestHandler<AddRouteToUserRequest, AddRouteToUserResponse>
{
    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor;
    private readonly ICommandExecutor commandExecutor;

    public AddRouteToUserHandlern(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
    {
        this.mapper = mapper;
        this.queryExecutor = queryExecutor;
        this.commandExecutor = commandExecutor;
    }
    public async Task<AddRouteToUserResponse> Handle(AddRouteToUserRequest request, CancellationToken cancellationToken)
    {
        var routeQuery = new GetRouteQuery { Id = request.RouteId };       
        var routeWithAscent = await queryExecutor.Execute(routeQuery);
        if (routeWithAscent == null)
        {
            new AddRouteToUserResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }
        var userIdstring = request.AuthenticationId;
        var userId = int.Parse(userIdstring);
        if (userId != request.ClimberId)
        {
            var userQuery = new GetUserQuery { UserId = request.ClimberId };
            var user = await queryExecutor.Execute(userQuery);
            user.Routes.Add(routeWithAscent);

            var command = new AddRouteToUserCommand
            {
                Parameter = user
            };
            var userWithAscent = await commandExecutor.Execute(command);

            return new AddRouteToUserResponse
            {
                Data = mapper.Map<UserDto>(userWithAscent)
            };
        }
        else
        {
            var userQuery = new GetUserQuery { UserId = userId };
            var user = await queryExecutor.Execute(userQuery);
            user.Routes.Add(routeWithAscent);
            var command = new AddRouteToUserCommand
            {
                Parameter = user
            };
            var userWithAscent = await commandExecutor.Execute(command);

            return new AddRouteToUserResponse
            {
                Data = mapper.Map<UserDto>(userWithAscent)
            };
        }
    }
}


