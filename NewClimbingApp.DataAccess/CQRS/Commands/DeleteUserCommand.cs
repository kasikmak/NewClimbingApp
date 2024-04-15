using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.CQRS.Commands;

public class DeleteUserCommand : CommandBase<User, User>
{
    public override async Task<User> Execute(NewClimbingAppContext context)
    {
        context.Users.Remove(this.Parameter);
        await context.SaveChangesAsync();
        return this.Parameter;
    }
}
