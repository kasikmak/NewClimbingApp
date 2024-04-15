using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.CQRS.Commands;

public class DeleteRouteCommand : CommandBase<Route, Route>
{
    public override async Task<Route> Execute(NewClimbingAppContext context)
    {
        context.Routes.Remove(this.Parameter);
        await context.SaveChangesAsync();
        return this.Parameter;
    }
}
