using MediatR;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static NewClimbingApp.DataAccess.Entities.User;

namespace NewClimbingApp.ApplicationServices.API.Domain.Requests.Users;

public class AddUserRequest : RequestBase, IRequest<AddUserResponse>
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Nationality { get; set; }
    public UserRole Role { get; set; }
    public string Password { get; set; }
}
