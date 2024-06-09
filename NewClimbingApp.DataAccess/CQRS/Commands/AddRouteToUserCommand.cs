using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.CQRS.Commands;

public class AddRouteToUserCommand : CommandBase<User, User>
{
    public async override Task<User> Execute(NewClimbingAppContext context)
    {
        context.Update(Parameter);
        await context.SaveChangesAsync();
        return this.Parameter;
    }
}
